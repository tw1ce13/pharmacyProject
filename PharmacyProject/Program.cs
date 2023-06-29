using PharmacyProject.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PharmacyProject.Domain;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Repositories;
using PharmacyProject.Services.Implementations;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Middleware;
using PharmacyProject;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAuthenticatedUser", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{ 
opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidIssuer = AuthOptions.issure,
        ValidateAudience = false,
        ValidAudience = AuthOptions.audience,
        ValidateLifetime = true,
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddSerilog();
});

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "yourCookieSessionName"; 
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});




builder.Services.AddDbContext<PharmacyContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddMyLibraryServices();





var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
app.UseMiddleware<UpdateErrorMiddleware>();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}/{id?}");
app.Run();

