using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Controllers
{
    public class DemoSuKienController : Controller
    {
        private readonly ConfigDbContext _context;
        private int _count = 1;

        public DemoSuKienController(ConfigDbContext context)
        {
            _context = context;
        }

        // GET: DemoSuKien
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewData["MaxEvent"] = (from x in _context.SuKien select x).Count();
            ViewData["CurrentFilter"] = SearchString; // Search hiện tại

            var sk = from m in _context.SuKien
                     select m;

            if (!String.IsNullOrEmpty(SearchString))
            {
                sk = sk.Where(s => s.TenSuKien!.Contains(SearchString));
            }

            return View(await sk.ToListAsync());
        }

        // GET: DemoSuKien/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.SuKien == null)
            {
                return NotFound();
            }

            var suKien = await _context.SuKien
                .FirstOrDefaultAsync(m => m.IDSuKien == id);
            if (suKien == null)
            {
                return NotFound();
            }

            return View(suKien);
        }

        // GET: DemoSuKien/Create
        public IActionResult Create()
        {
            //_count = (from x in _context.SuKien select x).Count() + 1;
            if (_context.SuKien != null)
            {
                foreach (var x in _context.SuKien)
                {
                    // random string
                    if (x.IDSuKien == $"SK{String.Format("{0:000}", _count)}".ToString())
                    {
                        _count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            ViewData["IDSuKien"] = $"SK{String.Format("{0:000}", _count)}".ToString();
            Console.WriteLine(ViewData["IDSuKien"]);
            return View();
        }

        // POST: DemoSuKien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDSuKien,TenSuKien,NgayBD,NgayKT,MoTa,IDNguoiCapNhat,IDNguoiTao,IDNguoiXoa,NgayCapNhat,NgayTao,NgayXoa,XoaTam,trangthai")] SuKien suKien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suKien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(suKien);
        }

        // GET: DemoSuKien/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.SuKien == null)
            {
                return NotFound();
            }

            var suKien = await _context.SuKien.FindAsync(id);
            if (suKien == null)
            {
                return NotFound();
            }
            return View(suKien);
        }

        // POST: DemoSuKien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDSuKien,TenSuKien,NgayBD,NgayKT,MoTa")] SuKien suKien)
        {
            if (id != suKien.IDSuKien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suKien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuKienExists(suKien.IDSuKien))
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
            return View(suKien);
        }

        // GET: DemoSuKien/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.SuKien == null)
            {
                return NotFound();
            }

            var suKien = await _context.SuKien.FirstOrDefaultAsync(m => m.IDSuKien == id);
            //var suKien = await _context.SuKien.FindAsync(id);
            if (suKien == null)
            {
                return NotFound();
            }

            return View(suKien);
        }

        // POST: DemoSuKien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SuKien == null)
            {
                return Problem("Entity set 'ConfigDbContext.SuKien'  is null.");
            }
            var suKien = await _context.SuKien.FindAsync(id);
            if (suKien != null)
            {
                _context.SuKien.Remove(suKien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuKienExists(string id)
        {
            if(_context.SuKien is not null)
                return _context.SuKien.Any(e => e.IDSuKien == id);
            return false;
        }
    }
}
