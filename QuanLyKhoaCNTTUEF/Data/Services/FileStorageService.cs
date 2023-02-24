namespace QuanLyKhoaCNTTUEF.Data.Services
{
    public class FileStorageService
    {
        private readonly string _uploadPath;

        public FileStorageService(IConfiguration configuration)
        {
            _uploadPath = configuration.GetValue<string>("FileStorage:UploadPath");
        }

        public async Task<string> StoreFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is null or empty");
            }

            string fileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";
            string filePath = Path.Combine(_uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public void DeleteFile(string fileName)
        {
            string filePath = Path.Combine(_uploadPath, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }

}
