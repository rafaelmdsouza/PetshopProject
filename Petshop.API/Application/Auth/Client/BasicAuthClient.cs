using System.Security.Principal;
namespace Petshop.API.Application.Auth.Client;

public class BasicAuthClient : IIdentity
{
    public string? AuthenticationType { get; set; }

    public bool IsAuthenticated { get; set; }

    public string? Name { get; set; }
}