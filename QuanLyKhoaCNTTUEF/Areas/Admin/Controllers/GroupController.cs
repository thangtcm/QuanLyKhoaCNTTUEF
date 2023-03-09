﻿using AspNetCoreHero.ToastNotification.Abstractions;
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

        public async Task<IActionResult> Dashboard()
        {
            //List<EventViewModel> groupDashboard= new List<EventViewModel>();
            var @event = await _context.Event.AsNoTracking().Include(x => x.Groups).ToListAsync();

            //foreach (Event item in @event)
            //{
            //    EventViewModel model = new EventViewModel();
            //    model.EventName = item.TenSuKien;

            //    if (item.Groups is not null)
            //    {
            //        var count = 0;
            //        foreach (var item2 in item.Groups)
            //        {
            //            if (count == 4)
            //                break;
            //            GroupViewModel group = new GroupViewModel();
            //            group.EventID = item2.EventID;
            //            group.GroupID = item2.GroupID;
            //            group.CreateDate = item2.NgayTao;
            //            group.UpdateDate = item2.NgayCapNhat;
            //            group.Decreption = item2.MoTa;

            //            model.Groups = (GroupViewModel)group;
            //            count++;
            //        }
            //    }
            //    groupDashboard.Add(model);
            //}

            return View(@event);
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
            var selectList = new SelectList(_context.Event, "EventID", "TenSuKien");

            
            // Lấy giá trị của TempData["IDSuKien"]
            var idSuKien = TempData["IDSuKien"] as int?;

            // Kiểm tra nếu giá trị có tồn tại và khác 0
            if (idSuKien.HasValue && idSuKien.Value != 0)
            {
                var suKien = _context?.Event?.Find(idSuKien);
                if(suKien is null)
                {
                    ViewData["EventID"] = selectList;
                    return View();
                }
                // Tạo một SelectListItem cho mục bạn muốn đưa lên đầu tiên
                var selectedItem = new SelectListItem { Value = idSuKien.Value.ToString(), Text = suKien?.TenSuKien?.ToString() };
                selectedItem.Selected = true;

                // Chèn mục mới vào vị trí đầu tiên của danh sách
                //selectList = new SelectList(selectList.Prepend(selectedItem), "Value", "Text");
                var newSelectList = new SelectList(selectList.Where(x => x.Value != selectedItem.Value), "Value", "Text");

                // Thêm mục mới vào đầu danh sách
                newSelectList = new SelectList(newSelectList.Prepend(selectedItem), "Value", "Text");

                // Lưu SelectList mới vào ViewData
                ViewData["EventID"] = newSelectList;
            }
            else
            {
                // Lưu SelectList vào ViewData
                ViewData["EventID"] = selectList;
            }    

            
            return View();
        }


        // POST: Nhoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupID,EventID,TenNhom,MoTa,NgayTao,NgayCapNhat")] Group @group)
        {
            //@group.Event = (Event?)ViewData["IDSuKien"];
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
