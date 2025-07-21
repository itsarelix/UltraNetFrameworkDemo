using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraNet.Application.Common;
using UltraNet.Application.Common.Enum;
using UltraNet.Application.Models;


namespace UltraNet.Application.Interfaces
{
    public interface IAuthService
    {
         Task<ReturnData<string>> Register(RegisterRequest request);
         Task<ReturnData<TokenResponse>> Login(LoginRequest request);
    }
}

