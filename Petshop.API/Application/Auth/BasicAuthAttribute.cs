using Microsoft.AspNetCore.Authorization;

namespace Petshop.API.Application.Auth;

public class BasicAuthAttribute : AuthorizeAttribute
{
    public BasicAuthAttribute()
        {
            AuthenticationSchemes = BasicAuthDefaults.AuthenticationScheme;
        }
}