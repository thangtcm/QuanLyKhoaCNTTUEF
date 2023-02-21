using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;
using QuanLyKhoaCNTTUEF.ViewModel;

namespace QuanLyKhoaCNTTUEF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _context;
        private int _count = 1;
        private readonly INotyfService _toastNotification;
        public GroupController(ApplicationDbContext context, INotyfService toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        // GET: Nhoms
        public async Task<IActionResult> Index()
        {
            if (_context.Group is not null)
                return View(await _context.Group.ToListAsync());
            return View();
        }

        // GET: Nhoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Group == null)
            {
                return NotFound();
            }

            var @group = await _context.Group
                .FirstOrDefaultAsync(m => m.GroupID == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }
        // GET: Nhoms/Create
        public IActionResult Create()
        {
            //if (_context.Group != null)
            //{
            //    foreach (var x in _context.Group)
            //    {
            //        // random string
            //        Console.WriteLine($"GR{string.Format("{0:000}", _count)}".ToString() + " Và " + x.EventID);
            //        if (x.GroupID == $"GR{string.Format("{0:000}", _count)}".ToString())
            //        {
            //            _count++;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}
            /*  if (_context.SuKien is not null)
                {
                    var sukien = _context.SuKien.Find(IDSuKien);
                    ViewData["IDSuKien"] = sukien;
                }    */

            ViewData["IDNhom"] = $"GR{string.Format("{0:000}", _count)}".ToString();
            
            ViewData["SuKien"] = new SelectList(_context.Event, "IDSuKien", "TenSuKien");
            ViewData["IDSuKien"] = TempData["IDSuKien"];
            return View();
        }


        // POST: Nhoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupID,EventID,TenNhom,MoTa,NgayTao,NgayCapNhat")] Group @group)
        {
            @group.Event = (Event?)ViewData["IDSuKien"];
            if (ModelState.IsValid)
            {
                _context.Add(@group);
                await _context.SaveChangesAsync();
                _toastNotification.Success("Tạo Nhóm Thành Công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["SuKien"] = new SelectList(_context.Event, "IDSuKien", "TenSuKien", @group.EventID);
            return View(@group);
        }

        // GET: Nhoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Group == null)
            {
                return NotFound();
            }

            var @group = await _context.Group.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            return View(@group);
        }

        // POST: Nhoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("GroupID,EventID,TenNhom,MoTa,NgayTao,NgayCapNhat")] Group @group)
        {
            if (id != @group.GroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhomExists(@group.GroupID))
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
            return View(@group);
        }

        public IActionResult EditMembers(int? id)
        {
            var group = _context.Group?.Include(g => g.MembersGroups).SingleOrDefault(g => g.GroupID == id);
            if (group == null)
            {
                return NotFound();
            }
            var allMembers = _context.Users.ToList();
            var vm = new MemberGroupViewModel
            {
                Group = group,
                Members = allMembers,
                SelectedMemberIDs = group.MembersGroups?.Select(gm => gm.UserID ?? "").ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditMembers(int? id, MemberGroupViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var group = _context.Group?.Include(g => g.MembersGroups).SingleOrDefault(g => g.GroupID == id);
            if (group == null)
            {
                return NotFound();
            }
            group.MembersGroups?.Clear();
            if (vm.SelectedMemberIDs != null)
            {
                foreach (var memberID in vm.SelectedMemberIDs)
                {
                    group.MembersGroups?.Add(new MembersGroups
                    {
                        GroupID = group.GroupID,
                        UserID = memberID
                    });
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
                // GET: Nhoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Group == null)
            {
                return NotFound();
            }

            var @group = await _context.Group
                .FirstOrDefaultAsync(m => m.GroupID == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Nhoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Group == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Group'  is null.");
            }
            var nhom = await _context.Group.FindAsync(id);
            if (nhom != null)
            {
                _context.Group.Remove(nhom);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhomExists(int? id)
        {
            if (_context.Group is not null)
                return _context.Group.Any(e => e.GroupID == id);
            return false;
        }
        public ActionResult DowloadData(string filename)
        {
            if (_context.Group is null)
                return NotFound();
            var customers = _context.Group.ToList();
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
