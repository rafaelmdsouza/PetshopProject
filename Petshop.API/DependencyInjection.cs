using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Petshop.API.Application.Auth;
using Petshop.API.Application.Auth.Handler;
using Petshop.API.Settings;

namespace Petshop.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });

        services.AddValidatorsFromAssembly(assembly);

        services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(BasicAuthDefaults.AuthenticationScheme,
        new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = BasicAuthDefaults.AuthenticationScheme,
            In = ParameterLocation.Header,
            Description = "Basic auth header"
        });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
                    {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = BasicAuthDefaults.AuthenticationScheme
                    }
                    },
                    new string[] {"Basic"}
                    }
    });
});

        services.AddAuthentication()
            .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>(
            BasicAuthDefaults.AuthenticationScheme, null
            );

        services.AddApiVersioning(cfg =>
        {
            cfg.AssumeDefaultVersionWhenUnspecified = true;
            cfg.DefaultApiVersion = ApiVersion.Default;
            cfg.ReportApiVersions = true;
            cfg.ApiVersionReader = new UrlSegmentApiVersionReader();
        });
        services.AddVersionedApiExplorer(cfg =>
        {
            cfg.GroupNameFormat = "'v'VVV";
            cfg.SubstituteApiVersionInUrl = true;
        });

        services.ConfigureOptions<SwaggerSettings>();

        return services;
    }
}