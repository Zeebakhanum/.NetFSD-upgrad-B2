var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

// Enable attribute routing
app.MapControllers();

// Default route (optional)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Register}/{id?}"
);

app.Run();