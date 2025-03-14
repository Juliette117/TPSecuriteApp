using IdentityServer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace IdentityServer.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUserAsync(UserRegister request);
        Task<TokenResponse> AuthenticateUserAsync(UserLogin login);
    }
}
