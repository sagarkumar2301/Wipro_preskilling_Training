var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1. Error Handling Middleware (Step 3)
app.UseExceptionHandler("/error");

// 2. Logging Middleware
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next();
    Console.WriteLine($"Response Status: {context.Response.StatusCode}");
});

// 3. Security
app.UseHttpsRedirection();

// 4. Static Files
app.UseDefaultFiles();
app.UseStaticFiles();

// 5. Error Endpoint (VERY IMPORTANT)
app.Map("/error", (HttpContext context) =>
{
    return Results.Text("Something went wrong!");
});

// 6. Default route (optional)
//app.MapGet("/", () => "Hello World!");

app.Run();