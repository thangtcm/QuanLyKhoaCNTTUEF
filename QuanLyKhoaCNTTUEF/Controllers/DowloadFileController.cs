using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using QuanLyKhoaCNTTUEF.Models;
using System.IO;

namespace QuanLyKhoaCNTTUEF.Controllers
{
    public class DowloadFileController : Controller
    {
        public ActionResult Index()
        {
            string filePaths = Directory.GetCurrentDirectory() + "/UploadFiles";
            List<FileModel> files = new List<FileModel>();
            /*foreach (var filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }*/

            return View(files);
        }
        /*public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.

            //string path = Path.Combine(HostingEnvironment.WebRootPath, "UploadFiles") + fileName;

            //Read the File data into Byte Array.
            //byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            //return File(bytes, "application/octet-stream", fileName);
            return View();
        }*/
    }
}
