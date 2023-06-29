using System;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.DAL.Repositories;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Implementations;
using PharmacyProject.Services.Interfaces;

namespace PharmacyProject;

public static class ServicesExtensions
{
    public static void AddMyLibraryServices(this IServiceCollection services)
    {
        services.AddScoped<IAvailabilityService, AvailabilityService>();
        services.AddScoped<IClassService, ClassService>();
        services.AddScoped<IDeliveryService, DeliveryService>();
        services.AddScoped<IDiscountService, DiscountService>();
        services.AddScoped<IDrugService, DrugService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IOrdDrugService, OrdDrugService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IPharmacyService, PharmacyService>();
        services.AddScoped<IRecipeDrugService, RecipeDrugService>();
        services.AddScoped<IRecipeService, RecipeService>();
        services.AddScoped<IWebService, WebService>();


        services.AddTransient<IAvailabilityRepository, AvailabilityRepository>();
        services.AddTransient<IBaseRepository<DrugClass>, DrugClassRepository>();
        services.AddTransient<IBaseRepository<Discount>, DiscountRepository>();
        services.AddTransient<IDeliveryRepository, DeliveryRepository>();
        services.AddTransient<IDrugRepository, DrugRepository>();
        services.AddTransient<IBaseRepository<Employee>, EmployeeRepository>();
        services.AddTransient<IBaseRepository<OrdDrug>, OrdDrugRepository>();
        services.AddTransient<IBaseRepository<Order>, OrderRepository>();
        services.AddTransient<IBaseRepository<Patient>, PatientRepository>();
        services.AddTransient<IBaseRepository<Pharmacy>, PharmacyRepository>();
        services.AddTransient<IBaseRepository<RecipeDrug>, RecipeDrugRepository>();
        services.AddTransient<IBaseRepository<Recipe>, RecipeRepository>();
        services.AddTransient<IBaseRepository<Web>, WebRepository>();
    }
}

