using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Petshop.API.Settings;

public class SwaggerSettings : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public SwaggerSettings(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }
    }

    private OpenApiInfo CreateVersionInfo (ApiVersionDescription description)
    {
        var info = new OpenApiInfo{
            Title = "Petshop",
            Version = description.ApiVersion.ToString()
        };

        if (description.IsDeprecated)
            info.Description = "This API version is deprecated.";

        return info;
    }
}