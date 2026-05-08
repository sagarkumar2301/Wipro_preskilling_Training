var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


// Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Custom Route
app.MapControllerRoute(
    name: "orderfood",
    pattern: "order-food",
    defaults: new { controller = "Restaurant", action = "OrderFood" });

app.Run();