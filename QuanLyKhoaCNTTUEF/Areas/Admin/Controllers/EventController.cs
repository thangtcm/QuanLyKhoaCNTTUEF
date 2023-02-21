using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;
using QuanLyKhoaCNTTUEF.ViewModel;

namespace QuanLyKhoaCNTTUEF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        private int _count = 1;
        private readonly INotyfService _toastNotification;
        public EventController(ApplicationDbContext context, INotyfService toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        // GET: DemoSuKien
        public async Task<IActionResult> Index(string SearchString)
        {
            //ViewData["MaxEvent"] = (from x in _context.SuKien select x).Count();
            ViewData["MaxEvent"] = _context.Event is not null ? _context.Event.Count() : 0;
            ViewData["CurrentFilter"] = SearchString; // Search hiện tại

            var sk = from m in _context.Event
                     select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                sk = sk.Where(s => s.TenSuKien!.Contains(SearchString));
            }

            return View(await sk.ToListAsync());
        }

        // GET: DemoSuKien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .AsNoTracking()
                .Include(m => m.Groups)
                .SingleOrDefaultAsync(m => m.EventID == id);

            if (@event == null)
            {
                return NotFound();
            }
            ViewSuKien _eventcontext = new()
            {
                GetID = id
            };
            TempData["IDSuKien"] = id;
            return View(@event);
        }


        // GET: DemoSuKien/Create
        public IActionResult Create()
        {
            //_count = (from x in _context.SuKien select x).Count() + 1;
            //if (_context.Event != null)
            //{
            //    foreach (var x in _context.Event)
            //    {
            //        random string
            //        if (x.EventID == $"SK{string.Format("{0:000}", _count)}".ToString())
            //        {
            //            _count++;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}
            ViewData["IDSuKien"] = $"SK{string.Format("{0:000}", _count)}".ToString();
            Console.WriteLine(ViewData["IDSuKien"]);
            return View();
        }

        // POST: DemoSuKien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,TenSuKien,NgayBD,NgayKT,MoTa,TrangThai,XoaTam,IDNguoiTao,NgayTao,IDNguoiCapNhat,NgayCapNhat,IDNguoiXoa,NgayXoa")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                _toastNotification.Success("Tạo Sự Kiện Thành Công");
                return RedirectToAction(nameof(Index));
            }
            
            return View(@event);
        }

        // GET: DemoSuKien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: DemoSuKien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,TenSuKien,NgayBD,NgayKT,MoTa,TrangThai,XoaTam,IDNguoiTao,NgayTao,IDNguoiCapNhat,NgayCapNhat,IDNguoiXoa,NgayXoa")] Event @event)
        {
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuKienExists(@event.EventID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Event == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Event'  is null.");
            }
            var @event = await _context.Event.FindAsync(id);
            if (@event != null)
            {
                _context.Event.Remove(@event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuKienExists(int? id)
        {
            if (_context.Event is not null)
                return _context.Event.Any(e => e.EventID == id);
            return false;
        }

        public ActionResult DowloadData(string filename)
        {
            if (_context.Event is null)
                return NotFound();
            var customers = _context.Event.ToList();
            try
            {
                _toastNotification.Success("Tải Dữ Liệu Thành Công");
                var stream = new MemoryStream();
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells.LoadFromDataTable(DownloadFileControllerHelpers.ToDataTable(customers.ToList()), true);
                    worksheet.Cells.AutoFitColumns();
                    package.Save();
                }
                stream.Position = 0;
                string excelname = $"{filename} - {DateTime.Now.ToString(string.Format("dd-M-yy"))}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelname);
            }
            catch (Exception ex)
            {
                _toastNotification.Success("Tải Dữ Liệu Không Thành Công - Lỗi " + ex.Message);
                return NotFound();
            }
        }
    }
}
