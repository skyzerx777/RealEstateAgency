using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Models;
using RealEstateAgency.Data;
using RealEstateAgency;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RealEstateAgencyContext>(options => options.UseSqlServer(connection));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.Name = "RealEstateAgency.Cookie";
            options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
            options.LoginPath = "/Login/Index";
            options.LogoutPath = "/Login/Index";
        });
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(1); // Установите желаемое время истечения сессии
//    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Куки сессии будут доступны только через HTTPS
//    // Установите опции сессии здесь, если требуется
//});
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<RealEstateAgencyContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index";
    options.LogoutPath = "/Login/Index";
    options.AccessDeniedPath = "/Login/AccessDenied";
    options.SlidingExpiration = false;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();
//app.UseSession();
//var expireTimeSpan = TimeSpan.FromMinutes(1);
//app.UseMiddleware<ExpireSessionMiddleware>(expireTimeSpan);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await DataSeeder.SeedData(userManager, roleManager);
}

app.Run();
