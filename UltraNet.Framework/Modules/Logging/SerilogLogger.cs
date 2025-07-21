using Serilog;
using UltraNet.Framework.Core.Interfaces.Logging;

namespace UltraNet.Modules.Logging
{
    public class SerilogLogger : ILoggerService
    {
        public void Info(string message)
        {
            Log.Information("[INFO] {Message}", message);
        }

        public void Warning(string message)
        {
            Log.Warning("[WARNING] {Message}", message);
        }

        public void Error(string message, Exception? ex = null)
        {
            if (ex != null)
                Log.Error(ex, "[ERROR] {Message}", message);
            else
                Log.Error("[ERROR] {Message}", message);
        }
    }
}
