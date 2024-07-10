using Kitchen.Data;
using Kitchen.Model;
using Kitchen.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DB");
builder.Services.AddDbContext<ApplicationDbContext>(option => 
{
    option.UseSqlServer(connection);
});
builder.Services.AddCors(x=> 
{
    x.AddPolicy("FirstPolicy", p => 
    {
        p.AllowAnyOrigin();
        p.AllowAnyHeader();
        p.AllowAnyMethod();
    });
});

builder.Services.AddScoped<IOrderRepo, OrderRepo>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(option =>
{
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("FirstPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
