using Duende.IdentityModel.Client;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityServer.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GenerateTokenAsync(IdentityUser user, string password);
        Task GenerateTokenAsync(IdentityUser user);
    }
}
