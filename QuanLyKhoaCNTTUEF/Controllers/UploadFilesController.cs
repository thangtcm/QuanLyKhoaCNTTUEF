using Microsoft.AspNetCore.Mvc;

namespace QuanLyKhoaCNTTUEF.Controllers
{
    public class UploadFilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(List<IFormFile> files)
        {
            try
            {
                if(files.Count > 0)
                {
                    foreach(var file in files)
                    {
                        string filename = file.FileName;
                        filename = Path.GetFileName(filename);
                        string uploadPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles", filename));
                        var stream = new FileStream(uploadPath, FileMode.Create);
                        file.CopyToAsync(stream);   
                    }
                    ViewBag.Message = "Total " + files.Count.ToString() + " Files uploads SuccessFully.";
                }    
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Error while uploading the file.";
            }
            return View();
        }
    }
}
