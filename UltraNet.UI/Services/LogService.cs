using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using UltraNet.UI.Model;
using UltraNet.UI.Services;

public class LogService : ILogService
{
    private readonly HttpClient _http;

    public LogService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("PublicClient");
    }

    public async Task<ReturnData<string>?> LogDataAsync()
    {
        var response = await _http.GetAsync("api/logging/LogData");

        if (!response.IsSuccessStatusCode)
            return null;

        return new ReturnData<string> { Message = "Log is created", IsSuccess=true };
    }
}