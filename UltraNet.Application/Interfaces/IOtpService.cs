using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraNet.Application.Common;
using UltraNet.Application.Models;

namespace UltraNet.Application.Interfaces
{
    public interface IOtpService
    {
         Task<ReturnData<string>> SendOtp(SendOtpRequest request);
         Task<ReturnData<string>> VerifyOtp(VerifyOtpRequest request);
    }
}
