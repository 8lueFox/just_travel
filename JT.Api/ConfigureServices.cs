using FluentValidation.AspNetCore;
using JT.Api.Filters;
using JT.Api.Services;
using JT.Application.Common.Interfaces;
using JT.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace JT.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        return services;
    }
}
