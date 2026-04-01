var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// ✅ Enable Session
builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// ✅ Use Session
app.UseSession();

app.MapControllers();

app.Run();