namespace QuanLyKhoaCNTTUEF.Data.Interfaces
{
    public interface IBufferedFileUploadService
    {
        Task<bool> UploadFile(IFormFile file);
    }
}
