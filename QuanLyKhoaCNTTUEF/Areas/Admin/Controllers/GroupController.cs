using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupController : Controller
    {
        private readonly ConfigDbContext _context;
        private int _count = 1;
        private readonly INotyfService _toastNotification;
        public GroupController(ConfigDbContext context, INotyfService toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        // GET: Nhoms
        public async Task<IActionResult> Index()
        {
            if (_context.Nhom is not null)
                return View(await _context.Nhom.ToListAsync());
            return View();
        }

        // GET: Nhoms/Details/5
        public async Task<IActionResult> Details(string? id)
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
            if (_context.Nhom != null)
            {
                foreach (var x in _context.Nhom)
                {
                    // random string
                    if (x.IDSuKien == $"GR{string.Format("{0:000}", _count)}".ToString())
                    {
                        _count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
          /*  if (_context.SuKien is not null)
            {
                var sukien = _context.SuKien.Find(IDSuKien);
                ViewData["IDSuKien"] = sukien;
            }    */
            ViewData["IDNhom"] = $"GR{string.Format("{0:000}", _count)}".ToString();
            ViewData["SuKien"] = new SelectList(_context.SuKien, "IDSuKien", "TenSuKien");
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
                _toastNotification.Success("Tạo Nhóm Thành Công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["SuKien"] = new SelectList(_context.SuKien, "IDSuKien", "TenSuKien", nhom.IDSuKien);
            return View(nhom);
        }

        // GET: Nhoms/Edit/5
        public async Task<IActionResult> Edit(string? id)
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
        public async Task<IActionResult> Delete(string? id)
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
            if (_context.Nhom is not null)
                return _context.Nhom.Any(e => e.IDNhom == id);
            return false;
        }
    }
}
