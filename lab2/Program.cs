
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using DAL.Entities;
using BLL.Interface;
using BLL.Services;
using DAL.Interface;
using DAL.Repository;
using lab2.Data;
using BLL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod();

    });
});
// Add services to the container.
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IAdministration, AdministrationService>();
builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<CarDealershipContext>();
builder.Services.AddDbContext<CarDealershipContext>();
builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler =
ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<IDbRepos, DbReposSQL>();
builder.Services.AddScoped<IDbCrud, DBDataOperation>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "CarDealershipApp";
    options.LoginPath = "/";
    options.AccessDeniedPath = "/";
    options.LogoutPath = "/";
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    //  401      
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var carDealershipContext =
    scope.ServiceProvider.GetRequiredService<CarDealershipContext>();
    await CarDealershipContextSeed.SeedAsync(carDealershipContext);
    await IdentitySeed.CreateUserRoles(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
