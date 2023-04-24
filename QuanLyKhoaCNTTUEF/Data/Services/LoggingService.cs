using QuanLyKhoaCNTTUEF.Data.Interfaces;

public class LoggingService : ILoggingService
{
    private readonly string _logFilePath;

    public LoggingService()
    {
        // Tạo đường dẫn đến file log
        var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Server_Logs");
        var logFileName = $"{DateTime.Now:yyyy-MM-dd}_Log.txt";
        _logFilePath = Path.Combine(logDirectory, logFileName);

        // Tạo thư mục lưu trữ log nếu chưa tồn tại
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }
    }

    public void Write(string user, string message)
    {
        // Ghi dữ liệu vào file
        using (var writer = new StreamWriter(_logFilePath, true))
        {
            writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {user} : {message}");
            writer.Flush();
        }
    }
}