using System;

namespace BankingFiltersApp.Services
{
    public class LoggingService : ILoggingService
    {
        public void Log(string message)
        {
            Console.WriteLine($"LOG: {message}");
        }
    }
}