using UltraNet.Framework.Core.Extensions;
using UltraNet.Framework.Core.Interfaces.Otp;
using UltraNet.Framework.Core.Constants;
using UltraNet.Infrastructure.Services;

using System.Text;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using UltraNet.Framework.Modules.Otp.Strategies;
using UltraNet.Application.Interfaces;
using UltraNet.Application.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddUltraLogging();
builder.Services.AddUltraCaching(builder.Configuration);
builder.Services.AddUltraOtp(builder.Configuration);
builder.Services.AddUltraRateLimiting();
builder.Services.AddSingleton<IMessageSenderService, CustomSmsSender>();
builder.Services.AddUltraAuth();
builder.Services.AddControllers().AddControllersAsServices();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<UltraNet.Application.Models.ICacheService, CacheService>();
builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<IOtpService, OtpService>();
builder.Services.AddScoped<IRateLimitingService, RateLimitingService>();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.Configure<TokenOptions>(
    builder.Configuration.GetSection("TokenOptions"));
var config = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config.Issuer,
            ValidAudience = config.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey))
        };
    });


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();

