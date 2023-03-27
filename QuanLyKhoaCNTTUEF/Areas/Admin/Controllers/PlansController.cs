using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Table;
using OfficeOpenXml;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Data.Interfaces;
using QuanLyKhoaCNTTUEF.Models;
using QuanLyKhoaCNTTUEF.Models.Files;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace QuanLyKhoaCNTTUEF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlansController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _toastNotification;
        private readonly IHostingEnvironment? _hostingEnvironment = null;
        private readonly UserManager<ApplicationUser> _userManager;


        public PlansController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, INotyfService toastNotification, IHostingEnvironment? hostingEnvironment)
        {
            _userManager = userManager;
            _context = context;
            _toastNotification = toastNotification;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Admin/Plans
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewData["MaxPlan"] = _context.Plan is not null ? _context.Plan.Count(): 0;
            ViewData["CurrentFilter"] = SearchString; // Search hiện tại

            var sk = from m in _context.Plan
                     select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                sk = sk.Where(s => s.TenKeHoach!.Contains(SearchString));
            }

            return View(await sk.ToListAsync());
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
                .FirstOrDefaultAsync(m => m.PlanID == id);
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
        public async Task<IActionResult> Create(Plan plan, List<IFormFile> PdfFiles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                foreach (var pdfFile in PdfFiles)
                {
                    if (pdfFile.FileName.EndsWith("pdf"))
                    {
                        var folder = "files/";
                        var fileName = Path.GetFileName(pdfFile.Name + DateTime.Now.ToString("dd-mm-yyyy") + ".pdf");
                        var filesPath = folder + fileName;

                        var filePath = Path.Combine(_hostingEnvironment?.WebRootPath, filesPath);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await pdfFile.CopyToAsync(stream);
                        }

                        var pdfFileInfo = new PdfFile
                        {
                            FileName = fileName,
                            DateUpload = DateTime.Now,
                            FilePath = "/" + filesPath,
                            PlanID = plan.PlanID
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
        public async Task<IActionResult> Edit(int id, Plan plan, List<IFormFile> PdfFiles)
        {
            if (id != plan.PlanID)
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
                                var folder = "files/";
                                var fileName = Path.GetFileName(pdfFile.Name + DateTime.Now.ToString("dd-mm-yyyy") + ".pdf");
                                var filesPath = folder + fileName;

                                var filePath = Path.Combine(_hostingEnvironment?.WebRootPath, filesPath);

                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await pdfFile.CopyToAsync(stream);
                                }

                                var pdfFileInfo = new PdfFile
                                {
                                    FileName = fileName,
                                    DateUpload = DateTime.Now,
                                    FilePath = "/" + filesPath,
                                    PlanID = plan.PlanID
                                };
                                _context.Add(pdfFileInfo);
                            }
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanExists((int)plan.PlanID))
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
                .FirstOrDefaultAsync(m => m.PlanID == id);
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
          return _context.Plan.Any(e => e.PlanID == id);
        }

        private async Task<string> UploadFile(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_hostingEnvironment?.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
        [HttpPost]
        public async Task<ActionResult> ImportDataExcel(IFormFile fileExcel)
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
                            Plan @plan = new()
                            {
                                TenKeHoach = worksheet.Cells[row, 2].Value.ToString(),
                                NgayTrinh = DateTime.Parse(worksheet.Cells[row, 3].Value.ToString()),
                                NgayDuyet = DateTime.Parse(worksheet.Cells[row, 4].Value.ToString()),
                                NguoiTrinh = worksheet.Cells[row, 5].Value.ToString(),
                                NguoiDuyet = worksheet.Cells[row, 6].Value.ToString(),


                            };
                            _context.Add(@plan);
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

        public ActionResult ExcelExport()
        {
            List<Plan> PlanData = _context.Plan.ToList();

            try
            {

                DataTable Dt = new DataTable();
                Dt.Columns.Add("ID", typeof(string));
                Dt.Columns.Add("Tên Kế Hoạch", typeof(string));
                Dt.Columns.Add("Ngày Trình", typeof(string));
                Dt.Columns.Add("Ngày Duyệt", typeof(string));
                Dt.Columns.Add("Người Trình", typeof(string));
                Dt.Columns.Add("Người Duyệt", typeof(string));

                foreach (var data in PlanData)
                {
                    DataRow row = Dt.NewRow();
                    row[0] = data.PlanID;
                    row[1] = data.TenKeHoach;
                    row[2] = data.NgayTrinh.ToString("dd/M/yyyy");
                    row[3] = data.NgayDuyet.ToString("dd/M/yyyy");
                    row[4] = data.NguoiTrinh;
                    row[5] = data.NguoiDuyet;
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
                    string excelname = $"Plan - {DateTime.Now.ToString(string.Format("dd-M-yy"))}.xlsx";
                    return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelname);
                }
            }
            catch (Exception ex)
            {
                _toastNotification.Success("Tải Dữ Liệu Không Thành Công - Lỗi " + ex.Message);
                return NotFound();
            }
        }
    }
}
