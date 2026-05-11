using OnlineBookStoreApp.Filters;
using OnlineBookStoreApp.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LoggingFilter>();
    options.Filters.Add<ExceptionFilter>();
});

builder.Services.AddRazorPages();

builder.Services.AddSession();

builder.Services.AddSingleton<IBookRepository, BookRepository>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();