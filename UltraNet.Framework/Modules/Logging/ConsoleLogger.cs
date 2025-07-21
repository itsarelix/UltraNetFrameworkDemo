using UltraNet.Framework.Core.Interfaces.Logging;

namespace UltraNet.Modules.Logging
{
    public class ConsoleLogger : ILoggerService
    {
        public void Info(string message) =>
            Console.WriteLine($"[INFO] {message}");

        public void Warning(string message) =>
            Console.WriteLine($"[WARNING] {message}");

        public void Error(string message, Exception? ex = null) =>
            Console.WriteLine($"[ERROR] {message} {ex?.Message}");
    }
}
