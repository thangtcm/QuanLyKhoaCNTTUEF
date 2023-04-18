using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using QuanLyKhoaCNTTUEF.Core;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;
using QuanLyKhoaCNTTUEF.ViewModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;

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

            var eventsWithUserGroups = await _context.Event.AsNoTracking()
                    .Include(x => x.Groups!)
                        .ThenInclude(g => g.MembersGroups!)
                            .ThenInclude(mg => mg.ApplicationUser)
                    .ToListAsync();

            if (!(await _userManager.IsInRoleAsync(user, Constants.Roles.Administrator)))
            {
                eventsWithUserGroups = await _context.Event
                    .Where(e => e.Groups.Any(g => g.MembersGroups.Any(mg => mg.UserID == user.Id)))
                    .Include(e => e.Groups!)
                        .ThenInclude(g => g.MembersGroups!)
                            .ThenInclude(mg => mg.ApplicationUser)
                    .Take(4)
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

        public async Task<IActionResult> DetailsMember(int? id)
        {
            if(id == null || _context.MembersGroups == null)
            {
                return NotFound();
            }
            var member = await _context.MembersGroups.FindAsync(id);
            var detailMember = await _context.Task_Assignments.AsNoTracking()
                .Include(x => x.MembersGroups)
                    .ThenInclude(x => x!.ApplicationUser)
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.MemberGroupID == member!.MemberGroupID);

            return View(detailMember);
        }

        // GET: Admin/Member/Create
        public async Task<IActionResult> AddMember(int? id)
        {
            if (id == null || _context.Group == null)
            {
                return NotFound();
            }
            var group = await _context.Group.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            var members = await _context.MembersGroups
                .Where(m => m.GroupID == id)
                .Select(m => m.UserID)
                .ToListAsync();
            var nonMembers = await _context.Users.Where(u => !members.Contains(u.Id)).ToListAsync();

            ViewData["UserId"] = new SelectList(nonMembers, "Id", "NameAndId");
            ViewData["GroupName"] = group.GroupName;
            ViewData["GroupID"] = id;
            var grouptask = await _context.Group.AsNoTracking().Include(u => u.Tasks).FirstOrDefaultAsync(u => u.GroupID == id);
            var tasks = grouptask?.Tasks.ToList();
            ViewData["TaskID"] = new SelectList(tasks, "TaskID", "TaskID");
            return View();
        }

        // POST: Admin/Member/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMember(int? id, List<string> userId)
        {
            try
            {
                foreach (var item in userId)
                {
                    var member = new MembersGroups { GroupID = id, UserID = item, RoleName = "Member" };
                    _context.Add(member);
                }
                await _context.SaveChangesAsync();
                _toastNotification.Success("Thêm thành viên thành công");
                return RedirectToAction("Details", "Group", new { id });
            }
            catch (Exception ex)
            {
                _toastNotification.Error(ex.Message);
            }
            return RedirectToAction("Details", "Group", new { id });
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

        public async Task<IActionResult> UpdateMember(int? id)
        {
            if (id == null || _context.MembersGroups == null)
            {
                return NotFound();
            }
            var membersGroups = await _context.MembersGroups.FindAsync(id);
            if (membersGroups == null)
            {
                return NotFound();
            }
            var assignTask = await _context.Task_Assignments.Include(x => x.Tasks)
                .Include(x => x.MembersGroups)
                    .ThenInclude(x => x!.ApplicationUser)
                .Where(x => x.MemberGroupID == id).FirstOrDefaultAsync();

            return View(assignTask);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMember(int id, TaskAssignments taskAssignments)
        {
            if (id != taskAssignments.MemberGroupID)
            {
                return NotFound();
            }
            var member = _context.MembersGroups.Where(x => x.MemberGroupID == id).FirstOrDefault();
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(taskAssignments);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!Task_AssignmentsExists(taskAssignments.MemberGroupID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Details", "Group", new { id = member?.GroupID });
                }
            }
            catch (Exception ex)
            {
                _toastNotification.Error(ex.ToString());
            }

            return View(taskAssignments);
        }

        public async Task<IActionResult> EditMember(int? id)
        {
            if (id == null || _context.MembersGroups == null)
            {
                return NotFound();
            }

            var membersGroups = await _context.MembersGroups.FindAsync(id);
            if (membersGroups == null)
            {
                return NotFound();
            }
            var group = membersGroups.GroupID!;
            var user = _context.Users.Where(u => membersGroups.UserID == u.Id).FirstOrDefault();
            ViewData["UserID"] = user!.Id;
            ViewData["UserName"] = user.NameAndId;
            ViewData["GroupID"] = _context?.Group?.Where(u => u.GroupID == group).FirstOrDefault()?.GroupID;
            ViewData["GroupName"] = _context?.Group?.Where(u => u.GroupID == group).FirstOrDefault()?.GroupName;
            var unassignedTaskNames = await _context!.Task
            .Where(gt => gt.GroupID == group && !_context.Task_Assignments.Any(ta => ta.TaskID == gt.TaskID)
            )
            .Select(t => new SelectListItem
            {
                Value = t.TaskID.ToString(),
                Text = t.TaskName
            })
            .ToListAsync();

            var currentTask = await _context.Task_Assignments
                .Where(ta => ta.MemberGroupID == membersGroups.MemberGroupID)
                .Select(ta => ta.Tasks)
                .FirstOrDefaultAsync();

            unassignedTaskNames.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "Choose Task".ToString()
            });
            var taskList = unassignedTaskNames;
            if (currentTask != null)
            {
                taskList = taskList.Concat(new[]
                {
                    new SelectListItem
                    {
                        Value = currentTask.TaskID.ToString(),
                        Text = currentTask.TaskName
                    }
                }).ToList();
            }

            ViewData["TaskList"] = new SelectList(taskList, "Value", "Text", currentTask?.TaskID.ToString());

            return View(membersGroups);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMember(int id, MembersGroups membersGroups, int TaskID, DateTime StartTime, DateTime EndTime)
        {
            if (id != membersGroups.MemberGroupID)
            {
                return NotFound();
            }
            try
            {
                if (TaskID != 0)
                {
                    var assignTask = _context.Task_Assignments
                        .Where(m => m.MembersGroups!.GroupID == membersGroups.GroupID && m.MemberGroupID == membersGroups.MemberGroupID)
                        .Include(m => m.MembersGroups)
                        .FirstOrDefault();
                    Console.WriteLine("ss      " + assignTask);
                    if (assignTask != null)
                    {
                        assignTask.TaskID = TaskID;
                        assignTask.StartTime = StartTime;
                        assignTask.EndTime = EndTime;
                        _context.Update(assignTask);
                    }
                    else
                    {
                        var newAssignTask = new TaskAssignments
                        {
                            MemberGroupID = membersGroups.MemberGroupID,
                            TaskID = TaskID,
                            StartTime = StartTime,
                            EndTime = EndTime
                        };
                        _context.Add(newAssignTask);
                    }
                }
                _context.Update(membersGroups);
                await _context.SaveChangesAsync();
                _toastNotification.Success("Chỉnh sửa thông tin thành viên thành công");
                return RedirectToAction("Details", new { id = membersGroups.GroupID });
            }
            catch (Exception ex)
            {
                _toastNotification.Error("Đã có lỗi xảy ra");
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Details", new { id = membersGroups.GroupID });
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
                    //row[4] = data.CreateDate.ToString("dd/M/yyyy");
                    //row[5] = data.UpdateDate.ToString("dd/M/yyyy");
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

        private bool Task_AssignmentsExists(int id)
        {
            return (_context.Task_Assignments?.Any(e => e.MemberGroupID == id)).GetValueOrDefault();
        }
    }
}
