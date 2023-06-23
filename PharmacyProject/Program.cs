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
using PharmacyProject.DAL.Middleware;
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
builder.Services.AddScoped<IAvailabilityService, AvailabilityService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IDrugService, DrugService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IOrdDrugService, OrdDrugService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPharmacyService, PharmacyService>();
builder.Services.AddScoped<IRecipeDrugService, RecipeDrugService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IWebService, WebService>();


builder.Services.AddTransient<IAvailabilityRepository, AvailabilityRepository>();
builder.Services.AddTransient<IBaseRepository<Class>, ClassRepository>();
builder.Services.AddTransient<IBaseRepository<Discount>, DiscountRepository>();
builder.Services.AddTransient<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddTransient<IDrugRepository, DrugRepository>();
builder.Services.AddTransient<IBaseRepository<Employee>, EmployeeRepository>();
builder.Services.AddTransient<IBaseRepository<OrdDrug>, OrdDrugRepository>();
builder.Services.AddTransient<IBaseRepository<Order>, OrderRepository>();
builder.Services.AddTransient<IBaseRepository<Patient>, PatientRepository>();
builder.Services.AddTransient<IBaseRepository<Pharmacy>, PharmacyRepository>();
builder.Services.AddTransient<IBaseRepository<RecipeDrug>, RecipeDrugRepository>();
builder.Services.AddTransient<IBaseRepository<Recipe>, RecipeRepository>();
builder.Services.AddTransient<IBaseRepository<Web>, WebRepository>();





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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

