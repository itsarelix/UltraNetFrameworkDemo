using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraNet.Application.Common;
using UltraNet.Application.Interfaces;
using UltraNet.Framework.Core.Interfaces.Logging;

namespace UltraNet.Infrastructure.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly ICompositeLogger _logger;

        public LoggingService(ICompositeLogger logger)
        {
            _logger = logger;       
        }

        public Task<ReturnData<bool>> GetLog()
        {
            try
            {
                _logger.Info("This is an information log!");
                _logger.Warning("This is a Warning log!");
                _logger.Error("Error log", new Exception("Test exception error!"));

                return Task.FromResult(ReturnData<bool>.Success(true, "Logs created successfully."));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ReturnData<bool>.Fail($"Failed to create logs: {ex.Message}"));
            }
        }
    }
}
