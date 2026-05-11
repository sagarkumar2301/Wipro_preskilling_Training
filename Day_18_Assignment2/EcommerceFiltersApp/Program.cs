using EcommerceFiltersApp.Filters;
using EcommerceFiltersApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LoggingFilter>();
    options.Filters.Add<ErrorHandlingFilter>();
});

builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<LoggingFilter>();
builder.Services.AddScoped<AuthFilter>();
builder.Services.AddScoped<ErrorHandlingFilter>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();