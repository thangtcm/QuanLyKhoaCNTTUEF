using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NuGet.Versioning;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using QuanLyKhoaCNTTUEF.Core;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;
using QuanLyKhoaCNTTUEF.ViewModel;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;

namespace QuanLyKhoaCNTTUEF.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _toastNotification;
        private readonly UserManager<ApplicationUser> _userManager;
        public GroupController(ApplicationDbContext context, INotyfService toastNotification, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            List<Event> eventsWithUserGroups = new();
            if((await _userManager.IsInRoleAsync(user, Constants.Roles.Administrator + "," + Constants.Roles.Teacher)))
            {
                eventsWithUserGroups = await _context.Event.AsNoTracking()
                    .Include(x => x.Groups!)
                        .ThenInclude(g => g.MembersGroups!)
                            .ThenInclude(mg => mg.ApplicationUser)
                    .ToListAsync();
                ViewData["groups"] = null;
            }    
            else
            {
                eventsWithUserGroups = await _context.Event
                    //.Include(e => e.Groups!)
                    //    .ThenInclude(g => g.MembersGroups!)
                    //        .ThenInclude(mg => mg.ApplicationUser)
                    //.Where(e => e.Groups.Any(g => g.MembersGroups.Any(mg => mg.UserID == user.Id)))
                    //.Take(4)
                    .ToListAsync();
                ViewData["groups"] = await _context.Group
                    .Include(g => g.MembersGroups!)
                            .ThenInclude(mg => mg.ApplicationUser)
                    .Where(g => g.MembersGroups.Any(mg => mg.UserID == user.Id))
                    .ToListAsync();
            }
            return View(eventsWithUserGroups);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Group == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var getUser = _context.MembersGroups.Where(x => x.UserID == user.Id && x.RoleName!.Equals("Leader"));

            var group = await _context.Group.FindAsync(id);
            var members = await _context.MembersGroups.AsNoTracking()
                .Include(u => u.ApplicationUser)
                .Where(g => g.GroupID == id).ToListAsync();
            if (group == null || members == null)
                NotFound();
            ViewData["GroupName"] = group!.GroupName;
            ViewData["GroupID"] = id;
            ViewData["IsLeader"] = getUser;
            return View(members);
        }

        // GET: Nhoms/Create
        public IActionResult Create()
        {
            var selectList = new SelectList(_context.Event, "EventID", "EventName");


            // Lấy giá trị của TempData["IDSuKien"]
            var idSuKien = TempData["IDSuKien"] as int?;
            var nonMembers = _context.Users.ToList();

            ViewData["UserId"] = new SelectList(nonMembers, "Id", "NameAndId");
            // Kiểm tra nếu giá trị có tồn tại và khác 0
            if (idSuKien.HasValue && idSuKien.Value != 0)
            {
                var suKien = _context?.Event?.Find(idSuKien);
                if (suKien is null)
                {
                    ViewData["EventID"] = selectList;
                    return View();
                }
                // Tạo một SelectListItem cho mục bạn muốn đưa lên đầu tiên
                var selectedItem = new SelectListItem { Value = idSuKien.Value.ToString(), Text = suKien?.EventName?.ToString() };
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
        public async Task<IActionResult> Create(Group @group, string userId)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _context.Add(@group);
                    await _context.SaveChangesAsync();
                    if (userId is not null)
                    {
                        var member = new MembersGroups { GroupID = @group.GroupID, UserID = userId, RoleName = "Leader" };
                        _context.Add(member);
                    }
                    await _context.SaveChangesAsync();
                    _toastNotification.Success("Tạo Nhóm Thành Công");
                    return RedirectToAction("Details", "Event", new { id = @group.EventID });
                }
            }
            catch (Exception ex)
            {
                _toastNotification.Error(ex.ToString());
            }
            ViewData["SuKien"] = new SelectList(_context.Event, "IDSuKien", "EventName", @group.EventID);
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
        public async Task<IActionResult> Edit(int? id, Group @group)
        {
            if (id != @group.GroupID)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(@group);
                        await _context.SaveChangesAsync();
                        _toastNotification.Success("Cập nhật thành công");
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
                    return RedirectToAction("Details", "Event", new { id = @group.EventID });
                }
            }
            catch (Exception ex)
            {
                _toastNotification.Error(ex.ToString());
            }

            return View(@group);
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
        public ActionResult ExcelExportGroup()
        {
            List<Group> GroupData = _context.Group.ToList();

            try
            {

                DataTable Dt = new DataTable();
                Dt.Columns.Add("Group ID", typeof(string));
                Dt.Columns.Add("Tên nhóm", typeof(string));
                Dt.Columns.Add("Mô Tả", typeof(string));
                foreach (var data in GroupData)
                {
                    DataRow row = Dt.NewRow();
                    row[0] = data.GroupID;
                    row[1] = data.GroupName;
                    row[2] = data.Description;
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
                    string excelname = $"Group - {DateTime.Now.ToString(string.Format("dd-M-yy"))}.xlsx";
                    return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelname);
                }
            }
            catch (Exception ex)
            {
                _toastNotification.Success("Tải Dữ Liệu Không Thành Công - Lỗi " + ex.Message);
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> ImportDataExcel(IFormFile fileExcel, int? id)
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
                            DataExcel dt = new();
                            Group @group = new()
                            {
                                GroupName = worksheet.Cells[row, 2].Value.ToString(),
                                Description = worksheet.Cells[row, 3].Value.ToString(),
                                EventID = id
                            };
                            _context.Add(@group);
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

        
    }
}
