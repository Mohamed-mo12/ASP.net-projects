using E_commerce.Models;
using E_commerce.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<ICategoriesRepo,CategoriesRepo>();
builder.Services.AddScoped<IDevicesRepo,DevicesRepo>();
builder.Services.AddScoped<IGamesRepo, GamesRepo>();



var connection =builder.Configuration.GetConnectionString("DB");

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connection));

builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Adminonly", policy =>
    {
        policy.RequireRole("Admin"); 
    });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
