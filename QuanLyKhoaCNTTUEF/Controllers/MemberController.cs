using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _toastNotification;
        private readonly UserManager<ApplicationUser> _userManager;

        public MemberController(ApplicationDbContext context, INotyfService _toastNotification, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this._toastNotification = _toastNotification;
            _userManager = userManager;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MembersGroups == null || _context.Task_Assignments == null)
            {
                return NotFound();
            }
            var member = await _context.MembersGroups.FindAsync(id);
            var detailMember = await _context.Task_Assignments.AsNoTracking()
                .Include(x => x.MembersGroups)
                    .ThenInclude(x => x!.ApplicationUser)
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.MemberGroupID == member!.MemberGroupID);

            if(detailMember == null)
            {
                return NotFound();
            }    

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
            if (!(await IsLeader(group.GroupID)))
            {
                return Forbid();
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

        public async Task<IActionResult> UpdateMember(int? id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (id == null || _context.MembersGroups == null)
            {
                return NotFound();
            }
            var membersGroups = await _context.MembersGroups.FindAsync(id);
            if (membersGroups == null)
            {
                return NotFound();
            }
            var assignTask = await _context.Task_Assignments
                .Include(x => x.Tasks)
                .Include(x => x.MembersGroups)
                    .ThenInclude(x => x!.ApplicationUser)
                .FirstOrDefaultAsync(x => x.MemberGroupID == membersGroups.MemberGroupID);
            if(user.Id != membersGroups.UserID)
            {
                _toastNotification.Error("Bạn chỉ phép được cập nhật tiến độ của bạn");
                return Forbid();
            }    
            if(assignTask == null)
            {
                _toastNotification.Error("Bạn chưa được phân nhiệm vụ");
                return RedirectToAction("Details", "Group", new { id = membersGroups.GroupID });
            }    

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
                        _toastNotification.Success("Cập Nhật thành công");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!Task_AssignmentsExists(taskAssignments.TaskAssignmentId))
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
            Console.WriteLine(await IsLeader(membersGroups.GroupID));
            if (!(await IsLeader(membersGroups.GroupID)))
            {
                return Forbid();
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
                var assignTask = _context.Task_Assignments
                    .Where(m => m.MembersGroups!.GroupID == membersGroups.GroupID && m.MemberGroupID == membersGroups.MemberGroupID)
                    .Include(m => m.MembersGroups)
                    .FirstOrDefault();
                Console.WriteLine("ss      " + assignTask);
                if (assignTask != null)
                {
                    if(TaskID == 0)
                    {
                        _context.Remove(assignTask);
                    }
                    else
                    {
                        assignTask.TaskID = TaskID;
                        assignTask.StartTime = StartTime;
                        assignTask.EndTime = EndTime;
                        _context.Update(assignTask);
                    }
                }
                else
                {
                    if(TaskID != 0)
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
                await _context.SaveChangesAsync();
                _toastNotification.Success("Chỉnh sửa thông tin thành viên thành công");
                return RedirectToAction("Details", "Group", new { id = membersGroups.GroupID });
                
            }
            catch (Exception ex)
            {
                _toastNotification.Error("Đã có lỗi xảy ra");
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MembersGroups == null)
            {
                return NotFound();
            }

            var membersGroups = await _context.MembersGroups
                .Include(m => m.ApplicationUser)
                .Include(m => m.Group)
                .FirstOrDefaultAsync(m => m.MemberGroupID == id);
            if (membersGroups == null)
            {
                return NotFound();
            }

            return View(membersGroups);
        }

        // POST: Admin/Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MembersGroups == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MembersGroups'  is null.");
            }
            var membersGroups = await _context.MembersGroups.FindAsync(id);
            var task_assign= await _context.Task_Assignments.FirstOrDefaultAsync(x => x.MemberGroupID == id);
            if (task_assign != null)
            {
                _context.Task_Assignments.Remove(task_assign);
            }
            if (membersGroups != null)
            {
                _context.MembersGroups.Remove(membersGroups);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Group", new { id = membersGroups?.GroupID });
        }

        private bool Task_AssignmentsExists(int id)
        {
            return (_context.Task_Assignments?.Any(e => e.TaskAssignmentId == id)).GetValueOrDefault();
        }

        private bool MemberExists(int id)
        {
            return (_context.MembersGroups?.Any(e => e.MemberGroupID == id)).GetValueOrDefault();
        }

        private async Task<bool> IsLeader(int? groupid)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var memberLeader = await _context.MembersGroups.FirstOrDefaultAsync(x => x.UserID == user.Id && x.GroupID == groupid);
            if (memberLeader != null && memberLeader.RoleName == "Leader")
            {
                return true;
            }

            return false;
        }
    }
}
