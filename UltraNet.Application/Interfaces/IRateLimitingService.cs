using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraNet.Application.Common;
using UltraNet.Application.Models;

namespace UltraNet.Application.Interfaces
{
    public interface IRateLimitingService
    {
       Task<ReturnData<string>> ControlRateLimit(RateLimitRequest request);
    }
}
