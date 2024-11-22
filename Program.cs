using Microsoft.EntityFrameworkCore;
using WebTest.Controllers;
using WebTest.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавление строки подключения в сервисы
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
builder.Services.AddTransient<HomeController>();
builder.Services.AddTransient<PriceController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
        name: "price",
        pattern: "{controller=Price}/{action=Index}");

app.MapControllerRoute(
        name: "getServicePrice",
        pattern: "{controller=Home}/{action=GetServicePrice}");

app.MapControllerRoute(
        name: "getMaterialPrice",
        pattern: "{controller=Home}/{action=GetMaterialPrice}");

app.MapControllerRoute(
       name: "getMastersByDate",
       pattern: "{controller=Home}/{action=GetMastersByDate}");

app.MapControllerRoute(
      name: "getTimesByDateAndMaster",
      pattern: "{controller=Home}/{action=GetTimesByDateAndMaster}");



app.Run();
