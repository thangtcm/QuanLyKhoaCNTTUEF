using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;
using QuanLyKhoaCNTTUEF.ViewModel;
using System.Data;
using System.IO;

namespace QuanLyKhoaCNTTUEF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _toastNotification;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        public EventController(ApplicationDbContext _context, INotyfService toastNotification, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            //_context = context;
            this._context = _context;
            _toastNotification = toastNotification;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        //[Authorize("")]
        // GET: DemoSuKien
        public async Task<IActionResult> Index(string SearchString)
        {
            //ViewData["MaxEvent"] = (from x in _context.SuKien select x).Count();
            ViewData["MaxEvent"] = _context.Event is not null ? _context.Event.Count() : 0;
            ViewData["CurrentFilter"] = SearchString; // Search hiện tại

            var sk = from m in _context.Event
                     //where m.TrangThai == 1 // Lấy những sự kiện  được duyệt
                     select m;
            //var e = from x in _context.Event
            //         where x.TrangThai == 0 // Lấy những sự kiện chưa được duyệt
            //         select x;

            if (!string.IsNullOrEmpty(SearchString))
            {
                sk = sk.Where(s => s.TenSuKien!.Contains(SearchString));
            }
            return View(await sk.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Index(int? approveId)
        {
            var ev = await _context.Event!.FindAsync(approveId);
            if (ev != null)
            {
                ev.TrangThai = 1;
                _context.Update(ev);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        // GET: DemoSuKien/Details/5
        public async Task<IActionResult> Details(int? id, string? groupName = null, string? taskName = null)
        {
            var @event = await _context.Event
                .AsNoTracking()
                .Include(m => m.Groups)
                .Include(m => m.Tasks)
                .SingleOrDefaultAsync(m => m.EventID == id);

            if (@event == null)
            {
                return NotFound();
            }

            // Lọc theo tên nhóm nếu có
            if (!string.IsNullOrEmpty(groupName))
            {
                @event.Groups = @event.Groups.Where(g => g.TenNhom!.Contains(groupName)).ToList();
            }

            // Lọc theo tên task nếu có
            if (!string.IsNullOrEmpty(taskName))
            {
                @event.Tasks = @event.Tasks.Where(t => t.TaskName!.Contains(taskName)).ToList();
            }

            TempData["IDSuKien"] = id;
            ViewBag.GroupName = groupName;
            ViewBag.TaskName = taskName;
            return View(@event);
        }

        public IActionResult Create()
        {
            //try
            //{
            //    var user = _httpContextAccessor?.HttpContext?.User;
            //    if (user?.Identity?.IsAuthenticated is false)
            //    {
            //        return RedirectToAction("ERROR", "Home", new { Area = "" });
            //    }
            //}
            //catch
            //{

            //}

            return View();
        }

        // POST: DemoSuKien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event @event)
        {
            try
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                _toastNotification.Success("Tạo Sự Kiện Thành Công");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _toastNotification.Error("Có lỗi xảy ra!!!");
            }
            return View(@event);
        }

        [HttpPost]
        public async Task<ActionResult> ImportDataExcel(IFormFile fileExcel)
        {
            var user = await _userManager.GetUserAsync(User);
            
            if (fileExcel == null || fileExcel.Length == 0)
            {
                ViewBag.Error = "Please Select a excel file";
                return View("Index");
            }
            else
            {
                if (fileExcel.FileName.EndsWith("xls") || fileExcel.FileName.EndsWith("xlsx"))
                {
                    string path = Path.GetTempFileName();
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await fileExcel.CopyToAsync(stream);
                    }

                    //read data from excel file
                    FileInfo existingFile = new FileInfo(path);
                    List<DataExcel> data = new List<DataExcel>();

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    //int sl = db.Table_Name.ToList().Count;
                    using (ExcelPackage package = new ExcelPackage(existingFile))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                        int colCount = worksheet.Dimension.End.Column;  //get Column Count
                        int rowCount = worksheet.Dimension.End.Row;     //get row count
                        for (int row = 2; row <= rowCount; row++)
                        {
                            //DataExcel dt = new();
                            Event event_temp = new()
                            {
                                TenSuKien = worksheet.Cells[row, 2].Value.ToString(),
                                StartTime = DateTime.Parse(worksheet.Cells[row, 3].Value.ToString()),
                                EndTime = DateTime.Parse(worksheet.Cells[row, 4].Value.ToString()),
                                Description = worksheet.Cells[row, 5].Value.ToString(),
                                NgayTao = DateTime.Parse(worksheet.Cells[row, 6].Value.ToString()),
                                NgayCapNhat = DateTime.Parse(worksheet.Cells[row, 6].Value.ToString()),
                                IDNguoiTao = user.FullName,
                                IDNguoiCapNhat = user.FullName
                                
                            };
                            _context.Add(event_temp);
                        }
                        ViewBag.data = data;
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Please Select a excel file";
                    return View("Index");
                }
            }
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
        public async Task<IActionResult> Edit(int id, [Bind("EventID,TenSuKien,StartTime,EndTime,Description,TrangThai,XoaTam,IDNguoiTao,NgayTao,IDNguoiCapNhat,NgayCapNhat,IDNguoiXoa,NgayXoa")] Event @event)
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
                        return RedirectToAction("Details", "Event");
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
        public ActionResult ExcelExport()
        {
            List<Event> EventData = _context.Event.ToList();

            try
            {

                DataTable Dt = new DataTable();
                Dt.Columns.Add("ID", typeof(string));
                Dt.Columns.Add("Tên Sự Kiện", typeof(string));
                Dt.Columns.Add("Ngày Bắt Đầu", typeof(string));
                Dt.Columns.Add("Ngày Kết Thúc", typeof(string));
                Dt.Columns.Add("Mô Tả", typeof(string));
                Dt.Columns.Add("Ngày Tạo", typeof(string));
                Dt.Columns.Add("Ngày Cập Nhật", typeof(string));
                
                foreach (var data in EventData)
                {
                    DataRow row = Dt.NewRow();
                    row[0] = data.EventID;
                    row[1] = data.TenSuKien;
                    row[2] = data.StartTime.ToString("dd/M/yyyy");
                    row[3] = data.EndTime.ToString("dd/M/yyyy");
                    row[4] = data.Description;
                    row[5] = data.NgayTao.ToString("dd/M/yyyy");
                    row[6] = data.NgayCapNhat.ToString("dd/M/yyyy");
                    Dt.Rows.Add(row);

                }

                var memoryStream = new MemoryStream();
                using (var excelPackage = new ExcelPackage(memoryStream))
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].LoadFromDataTable(Dt, true, TableStyles.None);
                    worksheet.Cells["A1:AN1"].Style.Font.Bold = true;
                    worksheet.DefaultRowHeight = 18;


                    worksheet.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    worksheet.Column(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Cells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    worksheet.DefaultColWidth = 20;
                    worksheet.Cells["B:G"].AutoFitColumns();

                    excelPackage.Save();
                    memoryStream.Position = 0;
                    string excelname = $"SuKien - {DateTime.Now.ToString(string.Format("dd-M-yy"))}.xlsx";
                    return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelname);
                }
            }
            catch (Exception ex)
            {
                _toastNotification.Success("Tải Dữ Liệu Không Thành Công - Lỗi " + ex.Message);
                return NotFound();
            }
        }
     
        //public ActionResult DowloadData(string filename)
        //{
        //    if (_context.Event is null)
        //        return NotFound();
        //    var customers = _context.Event.ToList();
        //    try
        //    {
        //        _toastNotification.Success("Tải Dữ Liệu Thành Công");
        //        var stream = new MemoryStream();
        //        using (var package = new ExcelPackage(stream))
        //        {
        //            var worksheet = package.Workbook.Worksheets.Add("Sheet1");
        //            worksheet.Cells.LoadFromDataTable(DownloadFileControllerHelpers.ToDataTable(customers.ToList()), true);
        //            worksheet.Cells.AutoFitColumns();
        //            package.Save();
        //        }
        //        stream.Position = 0;
        //        string excelname = $"{filename} - {DateTime.Now.ToString(string.Format("dd-M-yy"))}.xlsx";
        //        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelname);
        //    }
        //    catch (Exception ex)
        //    {
        //        _toastNotification.Success("Tải Dữ Liệu Không Thành Công - Lỗi " + ex.Message);
        //        return NotFound();
        //    }
        //}
    }
}
