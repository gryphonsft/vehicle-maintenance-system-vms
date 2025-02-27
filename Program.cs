using Microsoft.EntityFrameworkCore;
using AspProject1.Models;  // DbContext sýnýfýnýn bulunduðu namespace

var builder = WebApplication.CreateBuilder(args);

// appsettings.json'dan baðlantýyý al
var connectionString = builder.Configuration.GetConnectionString("AracTakipSistemiDB");

// DbContext'i DI container'a ekle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

//  Session servisini ekle
builder.Services.AddSession();

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

//  Session'ý kullanmadan önce ekle!
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hesap}/{action=Login}/{id?}");

app.Run();
