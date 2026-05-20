using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecureMvcDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Connection String
var connectionString =
builder.Configuration.GetConnectionString("DefaultConnection")
?? throw new InvalidOperationException(
"Connection string 'DefaultConnection' not found.");

// Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

// Identity Configuration
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();



builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// IMPORTANT
app.UseAuthentication();
app.UseAuthorization();

// Routing
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

// Create Roles + Admin User
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    // Create Roles
    string[] roles = { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Admin User
    string email = "admin@test.com";
    string password = "Admin@123";

    var user = await userManager.FindByEmailAsync(email);

    if (user == null)
    {
        user = new IdentityUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
    else
    {
        // VERY IMPORTANT
        if (!await userManager.IsInRoleAsync(user, "Admin"))
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}


app.Run();
