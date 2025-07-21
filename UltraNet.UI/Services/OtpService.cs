using System.Reflection;
using UltraNet.UI.Model;
using UltraNet.UI.Services;

public class OtpService : IOtpService
{
    private readonly HttpClient _http;

    public OtpService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("PublicClient");
    }

    public async Task<ReturnData<string>?> SendOtpAsync(SendOtpRequest model)
    {
        var response = await _http.PostAsJsonAsync("api/otp/sendotp", model);
 
        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<ReturnData<string>>();
        return result;
    }

    public async Task<ReturnData<string>?> VerifyOtpAsync(VerifyOtpRequest model)
    {
        var response = await _http.PostAsJsonAsync("api/otp/verifyotp", new { receiver = model.Receiver, inputCode = model.InputCode });
        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<ReturnData<string>>();
        return result;
    }
}