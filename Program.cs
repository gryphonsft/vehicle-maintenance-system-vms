using Microsoft.EntityFrameworkCore;
using AspProject1.Models;  // DbContext sýnýfýnýn bulunduðu namespace

var builder = WebApplication.CreateBuilder(args);

// appsettings.json'dan baðlantýyý al
var connectionString = builder.Configuration.GetConnectionString("AracTakipSistemiDB");

// DbContext'i DI container'a ekle
builder.Services.AddDbContext<AraclarContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware yapýlandýrmasý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
