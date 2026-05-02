using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StoreApp.Core.Interfaces;

namespace StoreApp.Services;

public static class ServicesRegistration
{
    public static void AddServicesRegistration(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IBrandService, BrandService>();
        builder.Services.AddScoped<ICategoriesService, CategoriesService>();

        builder.Services.AddScoped<IAuthService, AuthService>();

    }
}
