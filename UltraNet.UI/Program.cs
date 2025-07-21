using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UltraNet.UI.Data;
using UltraNet.UI.Services;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<UltraNet.UI.Services.IAuthenticationService, UltraNet.UI.Services.AuthenticationService>();
builder.Services.AddScoped<ITokenStorageService, TokenStorageService>();
builder.Services.AddScoped<IOtpService, OtpService>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IRateLimitService, RateLimitService>();

builder.Services.AddHttpClient("PublicClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5202/");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
