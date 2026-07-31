using Jym.BusinessLogic.ViewModels;
using Jym.Controllers;
using Jym.DataAccess;
using Jym.DataAccess.Data.Contexts;
using Jym.DataAccess.Data.Repositories;
using Jym.DataAccess.Data.Seeder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//IOC Container: send object to DI
//Inversion of control container 
// this mean everytime it see IPayment it creates for it instapay 
//builder.Services.AddScoped<IPayment, InstaPay>();
//builder.Services.AddTransient<IPayment, InstaPay>();
//builder.Services.AddSingleton<IPayment, InstaPay>();
//scoped for each request it will create only one instance after the request ends => used in db 
//transient 100 request 100 object, killed after the request is finished 
//singleton all of the requests will share one object (race condition might occur)


//builder.Services.AddScoped<IPlanRepository, PlanRepository>();



// keyservices
// Add services to the container.
//builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddJymDataAccess(connectionString);
builder.Services.AddJymBusinessLogic();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

//app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

if (app.Environment.IsDevelopment())
{
    await using var scope = app.Services.CreateAsyncScope();

    var dbContext = scope.ServiceProvider
        .GetRequiredService<JymDbContext>();

    // Apply pending migrations
    await dbContext.Database.MigrateAsync();

    // Seed the database
    await DatabaseSeeder.SeedAllAsync(dbContext);
}

app.Run();