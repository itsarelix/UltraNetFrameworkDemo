using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraNet.Application.Common;
using UltraNet.Application.Models;


namespace UltraNet.Application.Models
{
    public interface ICacheService
    {
        Task<ReturnData<string>> CacheData(CacheRequest cacheRequest);
    }
}
