using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Entities.Users;
using StoreApp.Core.Interfaces.IRepository;
using StoreApp.Core.validators;
using StoreApp.Infrastructure.Data;
using StoreApp.Infrastructure.Repositories;

namespace StoreApp.Infrastructure;

public static class InfrastructureRegistration
{

    public static void AddInfrastructureRegistration(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        builder.Services.AddScoped<IBrandRepository, BrandRepository>();

        
        builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

        builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
        builder.Services.AddScoped<IValidator<Categories>, CategoryValidator>();
        builder.Services.AddScoped<IValidator<Brands>, BrandValidator>();

    }

    public static void AddDbContextRegistration(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlite(
             builder.Configuration.GetConnectionString("DefaultConnection")
         ));
    }
}
