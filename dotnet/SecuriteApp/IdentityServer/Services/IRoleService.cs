
namespace IdentityServer.Services
{
    public interface IRoleService
    {
        Task AssignRoleAsync(string email, string role);
    }
}
