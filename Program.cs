using AngularWebApp.Data;
using AngularWebApp.Data.Entities.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(Program));

string DBconnectionString = builder.Configuration.GetConnectionString("connectionString")!;
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(DBconnectionString!);
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.UseCors(myAllowSpecificOrigins);

app.Run();
