using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PracticeMVC_DB_Identitty.Data;
using PracticeMVC_DB_Identitty.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PracticeMVCDBContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("str")));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("str")));

builder.Services.AddIdentity<Users, IdentityRole>(Options =>
{
    Options.Password.RequiredLength = 8;
    Options.Password.RequireNonAlphanumeric = true;
    Options.Password.RequireLowercase = true;
    Options.Password.RequireUppercase = true;
    Options.Password.RequireDigit = true;
    Options.User.RequireUniqueEmail = true;
    Options.SignIn.RequireConfirmedEmail = true;
    Options.SignIn.RequireConfirmedPhoneNumber = false;
    Options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//google authentication 

var configuration = builder.Configuration;

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});

////facebook authentication
//builder.Services.AddAuthentication().AddFacebook(facebookOptions =>
//{
//    facebookOptions.AppId = configuration["Authentication:Facebook:ClientId"];
//    facebookOptions.AppSecret = configuration["Authentication:Facebook:ClientSecret"];
//});

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add Session 
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IOTimeout = TimeSpan.FromSeconds(150);
    options.IdleTimeout = TimeSpan.FromSeconds(130);
    options.Cookie.Name = "Demo";
    options.Cookie.IsEssential = true;
    options.Cookie.HttpOnly = true;
});

// Accessing session value in View
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromSeconds(150);
    options.SlidingExpiration = true; // Resets the 30s timer on every activity
    options.LoginPath = "/Account/Login";
});

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

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
