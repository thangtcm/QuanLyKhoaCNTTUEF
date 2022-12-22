using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaCNTTUEF.Models;
using Task = QuanLyKhoaCNTTUEF.Models.Task;

namespace QuanLyKhoaCNTTUEF.Controllers
{
    public class DemoTask : Controller
    {
        private readonly ConfigDbContext _context;
        private int _count = 1;

        public DemoTask(ConfigDbContext context)
        {
            _context = context;
        }

        // GET: DemoTask
        public async Task<IActionResult> Index()
        {
            ViewData["MaxEvent"] = (from x in _context.Task select x).Count();
            return View(await _context.Task.ToListAsync());
        }

        // GET: DemoTask/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .FirstOrDefaultAsync(m => m.IDSuKien == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: DemoTask/Create
        public IActionResult Create()
        {
            if (_context.Task != null)
            {
                foreach (var x in _context.Task)
                {
                    // random string
                    if (x.IDTask == $"TASK{String.Format("{0:000}", _count)}".ToString())
                    {
                        _count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            ViewData["IDTask"] = $"TASK{String.Format("{0:000}", _count)}".ToString();
            return View();
        }

        // POST: DemoTask/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDSuKien,IDTask,TenTask,MoTa,NgayBD,NgayKT,TrangThai,ChiTiet,DanhGia")] Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: DemoTask/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: DemoTask/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDSuKien,IDTask,TenTask,MoTa,NgayBD,NgayKT,TrangThai")] Task task)
        {
            if (id != task.IDSuKien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.IDSuKien))
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
            return View(task);
        }

        // GET: DemoTask/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .FirstOrDefaultAsync(m => m.IDSuKien == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: DemoTask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Task == null)
            {
                return Problem("Entity set 'ConfigDbContext.Task'  is null.");
            }
            var task = await _context.Task.FindAsync(id);
            if (task != null)
            {
                _context.Task.Remove(task);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(string id)
        {
          return _context.Task.Any(e => e.IDSuKien == id);
        }
    }
}
