using System.Security.Claims;
using Core.Models.Account;
using Core.Models.Account.VM;
using Microsoft.AspNetCore.Identity;
using Services.Interface.Service.Authorization;

namespace Services.Service.Authorization;

public class ProfileService : IProfileService
{
    private readonly UserManager<ApplicationUser> _userManager;
    
    public ProfileService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ProfileViewModel> GetProfileDetailsAsync(ClaimsPrincipal claimsPrincipal)
    {
        var user = await _userManager.GetUserAsync(claimsPrincipal);

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