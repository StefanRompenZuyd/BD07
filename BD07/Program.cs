using BD07.Data;
using BD07.Services;
using BD07.Services.pub;
using Microsoft.AspNetCore.Identity;
using BD07.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BD07MedicineContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BD07MedicineContext") ?? throw new InvalidOperationException("Connection string 'BD07MedicineContext' not found.")));

builder.Services.AddRazorPages();
builder.Services.AddDbContext<MyMedContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyMedContext") ?? throw new InvalidOperationException("Connection string 'MyMedContext' not found.")));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSingleton<INotificationManager, NotificationManager>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
