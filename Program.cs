using HospitalManagementSystem.Components;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using HospitalManagementSystem.Services;
using HospitalManagementSystem.Interfaces;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

//
// =========================
// BLAZOR
// =========================
//
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//
// =========================
// RAZOR PAGES (IMPORTANT FOR IDENTITY UI)
// =========================
//
builder.Services.AddRazorPages();

//
// =========================
// DATABASE
// =========================
//
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});
builder.Services.AddSingleton<IEmailSender, DummyEmailSender>();
//
// =========================
// IDENTITY
// =========================
//
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

//
// =========================
// AUTH
// =========================
//
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

//
// =========================
// COOKIE CONFIG (FIXED PATHS)
// =========================
//
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";

    options.Cookie.HttpOnly = true;
    options.SlidingExpiration = true;
});

builder.Services.AddScoped<ISystemCodeRepository, SystemCodeRepository>();
builder.Services.AddScoped<ISystemCodeDetailsRepository, SystemCodeDetailsRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddMudServices();
var app = builder.Build();

//
// =========================
// PIPELINE
// =========================
//
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // (IMPORTANT ADDITION)

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

//
// =========================
// ROUTING (IMPORTANT)
// =========================
//
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapRazorPages(); // 🔥 REQUIRED FOR IDENTITY

app.Run();