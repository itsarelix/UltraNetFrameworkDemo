using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraNet.Application.Common;
using UltraNet.Application.Interfaces;
using UltraNet.Application.Models;
using UltraNet.Framework.Core.Interfaces.Otp;

namespace UltraNet.Infrastructure.Services
{
    public class OtpService : IOtpService
    {
        private readonly IOTPService _otp;
        public OtpService(IOTPService otp)
        {
            _otp = otp;
        }

        public async Task<ReturnData<string>> SendOtp(SendOtpRequest request)
        {
            try
            {
                var code = await _otp.GenerateAndSendOtpAsync(request.Receiver);
                return ReturnData<string>.Success(code, "OTP sent successfully.");
            }
            catch (Exception ex)
            {
                return ReturnData<string>.Fail($"Failed to send OTP: {ex.Message}");
            }
        }

        public async Task<ReturnData<string>> VerifyOtp(VerifyOtpRequest request)
        {
            var msg = "";
            try
            {
                var result = await _otp.VerifyOtpAsync(request.Receiver, request.InputCode);
                if (result == false)
                    msg = "OTP is not Verified.";

                else if (result == true)
                    msg = "OTP is Verfiyed.";

                return ReturnData<string>.Success(msg);
            }
            catch (Exception ex)
            {
                return ReturnData<string>.Fail($"Failed to send OTP: {ex.Message}");
            }
        }
    }
}
