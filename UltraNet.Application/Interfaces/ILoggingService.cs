using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraNet.Application.Common;

namespace UltraNet.Application.Interfaces
{
    public interface ILoggingService
    {
       Task<ReturnData<bool>> GetLog();
    }
}
