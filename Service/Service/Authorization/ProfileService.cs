using System.Security.Claims;
using Core.Models.Account;
using Core.Models.Account.VM;
using Microsoft.AspNetCore.Identity;
using Services.Interface.Service.Authorization;

namespace Services.Service.Authorization;

public class ProfileService(UserManager<ApplicationUser> userManager) : IProfileService
{
    public async Task<ProfileViewModel> GetProfileDetailsAsync(ClaimsPrincipal claimsPrincipal)
    {
        var user = await userManager.GetUserAsync(claimsPrincipal);

        if (user == null) return new ProfileViewModel();
        
        var profileViewModel = new ProfileViewModel
        {
            Email = user.Email ?? string.Empty,
            Username = user.UserName ?? string.Empty,
            PhoneNumber = user.PhoneNumber ?? string.Empty
        };

        return profileViewModel;
    }
}