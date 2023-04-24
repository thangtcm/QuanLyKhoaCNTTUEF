public class LoggingService : ILoggingService
{
    public void Log(string userName, string action)
    {
        // Lấy ngày hiện tại
        var today = DateTime.Today;

        // Tạo tên file log với định dạng yyyy_MM_dd_server_log.txt
        var fileName = $"{today:yyyy_MM_dd}_server_log.txt";

        // Lấy đường dẫn đến thư mục lưu trữ file log
        var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

        // Tạo thư mục lưu trữ file log nếu chưa tồn tại
        if (!Directory.Exists(logPath))
        {
            Directory.CreateDirectory(logPath);
        }

        // Tạo đường dẫn đến file log
        var logFile = Path.Combine(logPath, fileName);

        // Kiểm tra xem file log đã tồn tại hay chưa
        if (!File.Exists(logFile))
        {
            // Nếu chưa tồn tại, tạo mới file log
            using var sw = new StreamWriter(logFile);
        }

        // Mở file log để ghi thông tin
        using var sw = new StreamWriter(logFile, append: true);

        // Ghi thông tin vào file log
        var logMessage = $"{DateTime.Now} - {userName} - {action}";
        sw.WriteLine(logMessage);
    }
}