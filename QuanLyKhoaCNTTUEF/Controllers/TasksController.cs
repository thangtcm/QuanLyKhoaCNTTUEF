using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using QuanLyKhoaCNTTUEF.Core;
using QuanLyKhoaCNTTUEF.Data;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Controllers
{
    [Authorize(Roles =Constants.Roles.Administrator + "," + Constants.Roles.Teacher)]
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _toastNotification;
        private readonly UserManager<ApplicationUser> _userManager;
        public TasksController(ApplicationDbContext context, INotyfService toastNotification, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _toastNotification = toastNotification;
        }

        // GET: Admin/Tasks
        public async Task<IActionResult> Index(string SearchString)
        {
            //var applicationDbContext = _context.Task.Include(t => t.Event);
            //return View(await applicationDbContext.ToListAsync());
            ViewData["MaxTask"] = _context.Task is not null ? _context.Task.Count() : 0;
            ViewData["CurrentFilter"] = SearchString; // Search hiện tại

            var sk = from m in _context.Task
                     select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                sk = sk.Where(s => s.TaskName!.Contains(SearchString));
            }

            return View(await sk.ToListAsync());
        }
        // GET: Admin/Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var tasks = await _context.Task
                .Include(t => t.Event)
                .FirstOrDefaultAsync(m => m.TaskID == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // GET: Admin/Tasks/Create
        public IActionResult Create()
        {
            var selectList = new SelectList(_context.Event, "EventID", "EventName");


            // Lấy giá trị của TempData["IDSuKien"]
            var idSuKien = TempData["IDSuKien"] as int?;

            // Kiểm tra nếu giá trị có tồn tại và khác 0
            if (idSuKien.HasValue && idSuKien.Value != 0)
            {
                var suKien = _context?.Event?.Find(idSuKien);
                if (suKien is null)
                {
                    ViewData["EventID"] = selectList;
                    return View();
                }
                // Tạo một SelectListItem cho mục bạn muốn đưa lên đầu tiên
                var selectedItem = new SelectListItem { Value = idSuKien.Value.ToString(), Text = suKien?.EventName?.ToString() };
                selectedItem.Selected = true;

                // Chèn mục mới vào vị trí đầu tiên của danh sách
                //selectList = new SelectList(selectList.Prepend(selectedItem), "Value", "Text");
                var newSelectList = new SelectList(selectList.Where(x => x.Value != selectedItem.Value), "Value", "Text");

                // Thêm mục mới vào đầu danh sách
                newSelectList = new SelectList(newSelectList.Prepend(selectedItem), "Value", "Text");

                // Lưu SelectList mới vào ViewData
                ViewData["EventID"] = newSelectList;
            }
            else
            {
                // Lưu SelectList vào ViewData
                ViewData["EventID"] = selectList;
            }
            return View();
        }

        // POST: Admin/Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tasks tasks)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tasks);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Event", new { id = tasks.EventID });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ViewData["EventID"] = new SelectList(_context.Event, "EventID", "EventName", tasks.EventID);
            return View(tasks);

        }

        // GET: Admin/Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var tasks = await _context.Task.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            ViewData["EventID"] = new SelectList(_context.Event, "EventID", "EventName", tasks.EventID);
            ViewData["GroupList"] = new SelectList(_context.Group, "GroupID", "GroupName");
            return View(tasks);
        }

        // POST: Admin/Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tasks tasks)
        {
            if (id != tasks.TaskID)
            {
                return NotFound();
            }

            if (!tasks.GroupID.HasValue || tasks.GroupID == null)
                tasks.GroupID = null;

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(tasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasksExists(tasks.TaskID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Event", new { id = tasks.EventID });
            }
            //ViewData["EventID"] = new SelectList(_context.Event, "EventID", "EventName", tasks.EventID);
            return View(tasks);
        }

        // GET: Admin/Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var tasks = await _context.Task
                .Include(t => t.Event)
                .FirstOrDefaultAsync(m => m.TaskID == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // POST: Admin/Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Task == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Task'  is null.");
            }
            var tasks = await _context.Task.FindAsync(id);
            if (tasks != null)
            {
                _context.Task.Remove(tasks);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TasksExists(int? id)
        {
            return _context.Task.Any(e => e.TaskID == id);
        }

        public ActionResult ExcelExportTask()
        {
            List<Tasks> TaskData = _context.Task.ToList();

            try
            {

                DataTable Dt = new DataTable();
                Dt.Columns.Add("Task ID", typeof(string));
                Dt.Columns.Add("Tên Task", typeof(string));
                Dt.Columns.Add("Mô Tả", typeof(string));

                foreach (var data in TaskData)
                {
                    DataRow row = Dt.NewRow();
                    row[0] = data.TaskID;
                    row[1] = data.TaskName;
                    row[2] = data.Description;
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
                    string excelname = $"Task - {DateTime.Now.ToString(string.Format("dd-M-yy"))}.xlsx";
                    return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelname);
                }
            }
            catch (Exception ex)
            {
                _toastNotification.Success("Tải Dữ Liệu Không Thành Công - Lỗi " + ex.Message);
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult> ImportDataExcel(IFormFile fileExcel, int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (id == null)
                return NotFound();

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
                            Tasks @tasks = new()
                            {
                                TaskName = worksheet.Cells[row, 2].Value.ToString(),
                                Description = worksheet.Cells[row, 3].Value.ToString(),
                                EventID = id
                            };
                            _context.Add(@tasks);
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

        //public ActionResult DowloadData(string filename)
        //{
        //    if (_context.Task is null)
        //        return NotFound();
        //    var customers = _context.Task.ToList();
        //    try
        //    {
        //        _toastNotification.Success("Tải Dữ Liệu Thành Công");
        //        var stream = new MemoryStream();
        //        using (var package = new ExcelPackage(stream))
        //        {
        //            var worksheet = package.Workbook.Worksheets.Add("Sheet1");
        //            worksheet.Cells.LoadFromDataTable(DownloadFileControllerHelpers.ToDataTable(customers.ToList()), true);
        //            worksheet.Cells.AutoFitColumns();
        //            package.Save();
        //        }
        //        stream.Position = 0;
        //        string excelname = $"{filename} - {DateTime.Now.ToString(string.Format("dd-M-yy"))}.xlsx";
        //        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelname);
        //    }
        //    catch (Exception ex)
        //    {
        //        _toastNotification.Success("Tải Dữ Liệu Không Thành Công - Lỗi " + ex.Message);
        //        return NotFound();
        //    }
        //}
    }
}