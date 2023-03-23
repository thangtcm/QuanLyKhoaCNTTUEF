using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _toastNotification;

        public MemberController(ApplicationDbContext context, INotyfService _toastNotification)
        {
            _context = context;
            this._toastNotification = _toastNotification;
        }

        // GET: Admin/Member
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null || _context.Group == null)
            {
                return NotFound();
            }
            var members = await _context.Group.AsNoTracking()
                .Include(m => m.MembersGroups!)
                    .ThenInclude(m => m.ApplicationUser)
                .Include(m => m.MembersGroups!)
                    .ThenInclude(m => m.Task)
                .FirstOrDefaultAsync(g => g.GroupID == id);
            if (members == null)
                NotFound();
            return View(members);
        }

        // GET: Admin/Member/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MembersGroups == null)
            {
                return NotFound();
            }

            var membersGroups = await _context.MembersGroups
                .Include(m => m.ApplicationUser)
                .Include(m => m.Group)
                    .ThenInclude(m => m!.Event)
                .Include(m => m.Task)
                .FirstOrDefaultAsync(m => m.MemberGroupID == id);
            if (membersGroups == null)
            {
                return NotFound();
            }

            return View(membersGroups);
        }

        // GET: Admin/Member/Create
        public async Task<IActionResult> Create(int? id)
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
            
            ViewData["UserID"] = new SelectList(nonMembers, "Id", "NameAndId");
            ViewData["GroupName"] = group.TenNhom;
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
        public async Task<IActionResult> Create(int? id, List<string> userId)
        {
            try
            { 
                foreach(var item in userId)
                {
                    var member = new MembersGroups { GroupID = id, UserID = item };
                    _context.Add(member);
                }    
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = id });
            }
            catch(Exception ex)
            {
                _toastNotification.Error(ex.Message);
            }
            //ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", membersGroups.UserID);
            //ViewData["GroupID"] = new SelectList(_context.Group, "GroupID", "GroupID", membersGroups.GroupID);
            //ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "TaskID", membersGroups.TaskID);
            return RedirectToAction("Index", new { id = id });
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
            
            var group = membersGroups.GroupID;
            ViewData["UserID"] = membersGroups?.ApplicationUser!.FullName;
           // ViewData["GroupID"] = new SelectList(_context.Group, "GroupID", "GroupID", membersGroups?.GroupID);
            ViewData["GroupID"] = ViewData["GroupID"] ?? new SelectList(_context.Group, "GroupID", "GroupID", membersGroups?.GroupID);
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "TaskID", _context.Group.Include(m => m.Tasks).FirstOrDefault(m => m.GroupID == group));
            //membersGroups = await _context.MembersGroups.Include(u => u.UserID).Include(u => u.TaskID).Include(u => u.GroupID)
            //    .FirstOrDefaultAsync(u => u.MemberGroupID == id);
            return PartialView("EditMember", membersGroups);
        }

        // GET: Admin/Member/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            var group = membersGroups.GroupID;
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", membersGroups.UserID);
            ViewData["GroupID"] = new SelectList(_context.Group, "GroupID", "GroupID", membersGroups.GroupID);
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "TaskID", _context.Group.Include(m => m.Tasks).FirstOrDefault(m => m.GroupID == group));
            return View(membersGroups);
        }

        // POST: Admin/Member/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MembersGroups membersGroups)
        {
            if (id != membersGroups.MemberGroupID)
            {
                return NotFound();
            }

            try
            {
                _context.Update(membersGroups);
                _toastNotification.Success("Chỉnh sửa thành viên thành công");
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembersGroupsExists(membersGroups.MemberGroupID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //return RedirectToAction(nameof(Index));
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", membersGroups.UserID);
            ViewData["GroupID"] = new SelectList(_context.Group, "GroupID", "GroupID", membersGroups.GroupID);
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "TaskID", membersGroups.TaskID);
            return View(membersGroups);
        }

        // GET: Admin/Member/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MembersGroups == null)
            {
                return NotFound();
            }

            var membersGroups = await _context.MembersGroups
                .Include(m => m.ApplicationUser)
                .Include(m => m.Group)
                .Include(m => m.Task)
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
            if (membersGroups != null)
            {
                _context.MembersGroups.Remove(membersGroups);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembersGroupsExists(int id)
        {
          return (_context.MembersGroups?.Any(e => e.MemberGroupID == id)).GetValueOrDefault();
        }
    }
}
