using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuanLyKhoaCNTTUEF.Models;
using System.ComponentModel;
using System.IO;
using System.Web;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace QuanLyKhoaCNTTUEF.Controllers
{
    public class EpplusController : Controller
    {
       // EventFitEntities db = new EventFitEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                ViewBag.Error = "Please Select a excel file";
                return View("Index");
            }
            else
            {
                if (excelFile.FileName.EndsWith("xls") || excelFile.FileName.EndsWith("xlsx"))
                {
                    string path = Path.GetTempFileName();
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        excelFile.CopyToAsync(stream);
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
                        for (int row = 1; row <= rowCount; row++)
                        {
                            DataExcel dt = new DataExcel();
                            /*Table_Name table_ = new Table_Name();
                            table_.id = row + sl;
                            table_.fullname = worksheet.Cells[row, 2].Value.ToString();
                            db.Table_Name.Add(table_);
                            db.SaveChanges();*/
                            dt.ID = worksheet.Cells[row, 1].Value.ToString();
                            dt.Name = worksheet.Cells[row, 2].Value.ToString();
                            dt.City = worksheet.Cells[row, 3].Value.ToString();
                            dt.Country = worksheet.Cells[row, 4].Value.ToString();
                            data.Add(dt);
                        }
                        ViewBag.data = data;
                    }
                    return View("Success");
                }
                else
                {
                    ViewBag.Error = "Please Select a excel file";
                    return View("Index");
                }
            }
        }

        public ActionResult CreateExcel()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {

                //Add Worksheets in Excel file
                var workSheet = excel.Workbook.Worksheets.Add("TestSheet1");
                workSheet.TabColor = System.Drawing.Color.Black;
                workSheet.DefaultRowHeight = 12;

                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;

                //Create Excel file in Uploads folder of your project
                FileInfo excelFile = new FileInfo("~/UploadFiles/test.xlsx");

                //Add header row columns name in string list array
                List<DataExcel> data = new List<DataExcel>();
                for (int i = 0; i < 5; i++)
                {
                    DataExcel dt = new DataExcel();
                    dt.ID = i.ToString();
                    dt.Name = $"Name{i}";
                    dt.City = $"City{i}";
                    dt.Country = $"Country{i}";
                    data.Add(dt);
                }
                var headerRow = new List<string[]>()
                {
                    new string[] { "ID","Name", "City", "Country" }
                };

                // Get the header range
                string Range = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                // get the workSheet in which you want to create header

                // Popular header row data
                workSheet.Cells[Range].LoadFromArrays(headerRow);

                int start = 2;

                foreach (var dt in data)
                {
                    workSheet.Cells[start, 1].Value = dt.ID;
                    workSheet.Cells[start, 2].Value = dt.Name;
                    workSheet.Cells[start, 3].Value = dt.City;
                    workSheet.Cells[start, 4].Value = dt.Country;
                    start++;
                }
                var stream = new FileStream("~/UploadFiles/test.xlsx", FileMode.Create);
                //Save Excel file
                excel.SaveAs(excelFile);
            }
            byte[] fileBytes = System.IO.File.ReadAllBytes("~/UploadFiles/test.xlsx");
            string fileName = "test.xlsx";

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public ActionResult ShowData()
        {
           // List<Table_Name> lst = new List<Table_Name>();
            //lst = db.Table_Name.ToList();
            return View();
        }
    }
}
