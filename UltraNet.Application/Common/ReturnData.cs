using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraNet.Application.Common.Enum;

namespace UltraNet.Application.Common
{
    public class ReturnData<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static ReturnData<T> Success(T? data = default, string? message = null)
        {
            return new ReturnData<T>
            {
                IsSuccess = true,
                Message = message ?? "Operation succeeded",
                Data = data
            };
        }

        public static ReturnData<T> Fail(string? message = null)
        {
            return new ReturnData<T>
            {
                IsSuccess = false,
                Message = message ?? "Operation failed",
                Data = default
            };
        }
    }
}
