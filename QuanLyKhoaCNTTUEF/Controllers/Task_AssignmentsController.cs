using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Controllers
{
    [Authorize]
    public class Task_AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Task_AssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Task_Assignments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Task_Assignments.Include(t => t.Tasks);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Task_Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Task_Assignments == null)
            {
                return NotFound();
            }

            var task_Assignments = await _context.Task_Assignments
                .Include(t => t.Tasks)
                .FirstOrDefaultAsync(m => m.MemberGroupID == id);
            if (task_Assignments == null)
            {
                return NotFound();
            }

            return View(task_Assignments);
        }

        // GET: Admin/Task_Assignments/Create
        public IActionResult Create()
        {
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "TaskID");
            return View();
        }

        // POST: Admin/Task_Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberID,TaskID,StartTime,EndTime,Progress,Status,Description,Note")] TaskAssignments task_Assignments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task_Assignments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "TaskID", task_Assignments.TaskID);
            return View(task_Assignments);
        }

        // GET: Admin/Task_Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Task_Assignments == null)
            {
                return NotFound();
            }

            var task_Assignments = await _context.Task_Assignments.FindAsync(id);
            if (task_Assignments == null)
            {
                return NotFound();
            }
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "TaskID", task_Assignments.TaskID);
            return View(task_Assignments);
        }

        // POST: Admin/Task_Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberID,TaskID,StartTime,EndTime,Progress,Status,Description,Note")] TaskAssignments task_Assignments)
        {
            if (id != task_Assignments.MemberGroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task_Assignments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Task_AssignmentsExists(task_Assignments.MemberGroupID))
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
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "TaskID", task_Assignments.TaskID);
            return View(task_Assignments);
        }

        // GET: Admin/Task_Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Task_Assignments == null)
            {
                return NotFound();
            }

            var task_Assignments = await _context.Task_Assignments
                .Include(t => t.Tasks)
                .FirstOrDefaultAsync(m => m.MemberGroupID == id);
            if (task_Assignments == null)
            {
                return NotFound();
            }

            return View(task_Assignments);
        }

        // POST: Admin/Task_Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Task_Assignments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Task_Assignments'  is null.");
            }
            var task_Assignments = await _context.Task_Assignments.FindAsync(id);
            if (task_Assignments != null)
            {
                _context.Task_Assignments.Remove(task_Assignments);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Task_AssignmentsExists(int id)
        {
            return (_context.Task_Assignments?.Any(e => e.MemberGroupID == id)).GetValueOrDefault();
        }
    }
}
