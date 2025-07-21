using UltraNet.Framework.Core.Interfaces.Logging;

namespace UltraNet.Framework.Modules.Logging.Decorators
{
    public class CompositeLogger : ICompositeLogger
    {
        private readonly IEnumerable<ILoggerService> _loggers;

        public CompositeLogger(IEnumerable<ILoggerService> loggers)
        {
            _loggers = loggers;
        }

        public void Info(string message)
        {
            foreach (var logger in _loggers)
                logger.Info(message);
        }

        public void Warning(string message)
        {
            foreach (var logger in _loggers)
                logger.Warning(message);
        }

        public void Error(string message, Exception? ex = null)
        {
            foreach (var logger in _loggers)
                logger.Error(message, ex);
        }
    }
}
