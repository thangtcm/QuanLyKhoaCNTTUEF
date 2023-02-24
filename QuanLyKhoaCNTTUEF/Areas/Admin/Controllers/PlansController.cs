using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Data.Interfaces;
using QuanLyKhoaCNTTUEF.Data.Services;
using QuanLyKhoaCNTTUEF.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace QuanLyKhoaCNTTUEF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlansController : Controller
    {
        private readonly ApplicationDbContext _context;
        readonly IBufferedFileUploadService _bufferedFileUploadService;

        public PlansController(ApplicationDbContext context, IBufferedFileUploadService bufferedFileUploadService)
        {
            _context = context;
            _bufferedFileUploadService = bufferedFileUploadService;
        }

        // GET: Admin/Plans
        public async Task<IActionResult> Index()
        {
              return View(await _context.Plan.ToListAsync());
        }

        // GET: Admin/Plans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plan == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan
                .FirstOrDefaultAsync(m => m.IDKeHoach == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // GET: Admin/Plans/ViewPdf/5
        public IActionResult ViewPdf(int? id)
        {
            var plan = _context.Plan?.Find(id);
            if (plan == null)
            {
                return NotFound();
            }
            var filePath = plan.PathFilePDF;
            var stream = new FileStream(filePath, FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }

        // GET: Admin/Plans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Plans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDKeHoach,TenKeHoach,NgayTrinh,NgayDuyet,NguoiTrinh,NguoiDuyet")] Plan plan, IFormFile pdfFile)
        {
            if (ModelState.IsValid)
            {
                if (pdfFile != null && pdfFile.Length > 0)
                {
                    var fileName = Path.GetFileName(pdfFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await pdfFile.CopyToAsync(stream);
                    }

                    plan.PathFilePDF = Path.Combine("pdf", fileName);
                }
                _context.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }

        // GET: Admin/Plans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plan == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            return View(plan);
        }

        // POST: Admin/Plans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDKeHoach,TenKeHoach,NgayTrinh,NgayDuyet,NguoiTrinh,NguoiDuyet,PdfFileName,PdfFilePath")] Plan plan, IFormFile pdfFile)
        {
            if (id != plan.IDKeHoach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (pdfFile != null && pdfFile.Length > 0)
                    {
                        var fileName = Path.GetFileName(pdfFile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await pdfFile.CopyToAsync(stream);
                        }

                        plan.PathFilePDF = Path.Combine("pdf", fileName);
                    }
                    _context.Update(plan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanExists(plan.IDKeHoach))
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
            return View(plan);
        }

        // GET: Admin/Plans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plan == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan
                .FirstOrDefaultAsync(m => m.IDKeHoach == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // POST: Admin/Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plan == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Plan'  is null.");
            }
            var plan = await _context.Plan.FindAsync(id);
            if (plan != null)
            {
                _context.Plan.Remove(plan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanExists(int id)
        {
          return _context.Plan.Any(e => e.IDKeHoach == id);
        }
    }
}
