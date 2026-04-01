using StudentApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// ✅ Register DI
builder.Services.AddSingleton<IContactService, ContactService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// Attribute routing
app.MapControllers();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=ShowContacts}/{id?}");

app.Run();