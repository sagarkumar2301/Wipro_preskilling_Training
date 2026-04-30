using Serilog;

public class LoggerService
{
    public static void Configure()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("log.txt")
            .CreateLogger();
    }
}
