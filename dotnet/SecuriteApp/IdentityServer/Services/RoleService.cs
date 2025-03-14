using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityServer.Services
{
    public class RoleService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AssignRoleAsync(string email, string role)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user == null) return;

            await _userManager.AddToRoleAsync(user, role);
        }
    }
}
