using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Data.Interfaces;
using QuanLyKhoaCNTTUEF.Models;
using QuanLyKhoaCNTTUEF.Models.Files;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace QuanLyKhoaCNTTUEF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlansController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment? _hostingEnvironment = null;

        public PlansController(ApplicationDbContext context, IHostingEnvironment? hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Admin/Plans
        public async Task<IActionResult> Index()
        {
            ViewData["MaxPlan"] = _context.Plan is not null ? _context.Plan.Count(): 0;
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
                .Include(p => p.PdfFiles)
                .FirstOrDefaultAsync(m => m.IDKeHoach == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
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
        public async Task<IActionResult> Create([Bind("IDKeHoach,TenKeHoach,NgayTrinh,NgayDuyet,NguoiTrinh,NguoiDuyet")] Plan plan, List<IFormFile> PdfFiles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                foreach (var pdfFile in PdfFiles)
                {
                    if (pdfFile.FileName.EndsWith("pdf"))
                    {
                        var filesPath = Path.Combine(_hostingEnvironment?.WebRootPath, "files");
                        var fileName = Path.GetFileName(pdfFile.FileName);
                        var filePath = Path.Combine(_hostingEnvironment?.WebRootPath, filesPath, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await pdfFile.CopyToAsync(stream);
                        }

                        var pdfFileInfo = new PdfFile
                        {
                            FileName = fileName,
                            DateUpload = DateTime.Now,
                            FilePath = filePath,
                            IDKeHoach = plan.IDKeHoach
                        };
                        _context.Add(pdfFileInfo);
                    }
                }
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
        public async Task<IActionResult> Edit(int id, [Bind("IDKeHoach,TenKeHoach,NgayTrinh,NgayDuyet,NguoiTrinh,NguoiDuyet")] Plan plan, List<IFormFile> PdfFiles)
        {
            if (id != plan.IDKeHoach)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plan);
                    if (PdfFiles != null && PdfFiles.Count > 0)
                    {
                        foreach (var pdfFile in PdfFiles)
                        {
                            if (pdfFile.FileName.EndsWith("pdf"))
                            {
                                var filesPath = Path.Combine(_hostingEnvironment?.WebRootPath, "files");
                                var fileName = Path.GetFileName(pdfFile.FileName);
                                var filePath = Path.Combine(_hostingEnvironment?.WebRootPath, filesPath, fileName);
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await pdfFile.CopyToAsync(stream);
                                }

                                var pdfFileInfo = new PdfFile
                                {
                                    FileName = fileName,
                                    DateUpload = DateTime.Now,
                                    FilePath = filePath,
                                    IDKeHoach = id
                                };
                                _context.Add(pdfFileInfo);
                            }
                        }
                    }
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
                if(plan.PdfFiles != null)
                {
                    foreach (var filepdf in plan.PdfFiles)
                    {
                        plan.PdfFiles.Remove(filepdf);
                        _context?.PdfFile?.Remove(filepdf);
                    }
                }    
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
