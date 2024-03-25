using Application.Contracts.Identity;
using Application.Services.AuthentificationServices;
using Application.Services.CarInfoService;
using Application.Services.CarsAndDriversService;
using Application.Services.DriversInfoService;
using Application.Services.JokeService;
using Application.Services.Utils;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfraRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DbContext")));
        services.AddAuthentication(
            options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            });

        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<DbContext>()
            .AddDefaultTokenProviders();
        services.AddScoped<IAuthService, AuthService>();
        services.AddHttpClient();
        // services.AddScoped<IAuthorization, AuthorizationService>();
        services.AddScoped<UtilsService, UtilsService>();
        services.AddScoped<JokeService, JokeService>();
        services.AddScoped<CarInfoService, CarInfoService>();
        services.AddScoped<CarsAndDriversService, CarsAndDriversService>();
        services.AddScoped<DriverInfoService, DriverInfoService>();
        return services;
    }
}