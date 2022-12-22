using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Controllers
{
    public class NhomsController : Controller
    {
        private readonly ConfigDbContext _context;

        public NhomsController(ConfigDbContext context)
        {
            _context = context;
        }

        // GET: Nhoms
        public async Task<IActionResult> Index()
        {
            if(_context.Nhom is not null)
              return View(await _context.Nhom.ToListAsync());
            return View();
        }

        // GET: Nhoms/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhom == null)
            {
                return NotFound();
            }

            var nhom = await _context.Nhom
                .FirstOrDefaultAsync(m => m.IDNhom == id);
            if (nhom == null)
            {
                return NotFound();
            }

            return View(nhom);
        }

        // GET: Nhoms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDNhom,IDSuKien,TenNhom,MoTa,NgayTao,NgayCapNhat")] Nhom nhom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhom);
        }

        // GET: Nhoms/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhom == null)
            {
                return NotFound();
            }

            var nhom = await _context.Nhom.FindAsync(id);
            if (nhom == null)
            {
                return NotFound();
            }
            return View(nhom);
        }

        // POST: Nhoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDNhom,IDSuKien,TenNhom,MoTa,NgayTao,NgayCapNhat")] Nhom nhom)
        {
            if (id != nhom.IDNhom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhomExists(nhom.IDNhom))
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
            return View(nhom);
        }

        // GET: Nhoms/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nhom == null)
            {
                return NotFound();
            }

            var nhom = await _context.Nhom
                .FirstOrDefaultAsync(m => m.IDNhom == id);
            if (nhom == null)
            {
                return NotFound();
            }

            return View(nhom);
        }

        // POST: Nhoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhom == null)
            {
                return Problem("Entity set 'ConfigDbContext.Nhom'  is null.");
            }
            var nhom = await _context.Nhom.FindAsync(id);
            if (nhom != null)
            {
                _context.Nhom.Remove(nhom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhomExists(string id)
        {
            if(_context.Nhom is not null)
                return _context.Nhom.Any(e => e.IDNhom == id);
            return false;
        }
    }
}
