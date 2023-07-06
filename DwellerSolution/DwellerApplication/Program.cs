using DwellerApplication.Application.Interfaces;
using DwellerApplication.Application.Services.Household;
using DwellerApplication.Application.Services.Registration;
using DwellerApplication.Application.Services.RoleServices;
using DwellerApplication.Application.Services.User;
using DwellerApplication.Core.Models.User;
using DwellerApplication.Infrastructure.Data;
using DwellerApplication.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Infrastructure-services
builder.Services.AddScoped<IHouseRepository, HouseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Application-services
builder.Services.AddScoped<RegistrationServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<HouseServices>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<SeedUserData>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

    //Initialize various roles for the Dweller application
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<SeedUserData>();
        //await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
        await initialiser.SeedUsersAsync();
    }
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

app.UseAuthorization();

// Map areas
app.MapControllerRoute(
    name: "Household",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
