using Core.Constants;
using Core.Enums;
using Core.Features;
using Core.Models.Account;
using Core.Models.Account.ViewModels;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces.Services;

namespace Services.Services;

public class RegisterService : IRegisterService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public RegisterService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task<IdentityResult> RegisterUserAsync(RegisterViewModel registerViewModel)
    {
        var user = new ApplicationUser
        {
            Email = registerViewModel.Email,
            StatusId = (int)Status.Active,
            CreatedDateT = DateTime.UtcNow,
            UserName = string.IsNullOrWhiteSpace(registerViewModel.Username) ? registerViewModel.Email : registerViewModel.Username,
            EmailConfirmed = !EmailFeature.EmailVerifiedIsEnabled
        };
        
        var result = await _userManager.CreateAsync(user, registerViewModel.Password);
        if (!result.Succeeded) return result;
        
        var defaultRole = await _userManager.GetRolesAsync(user);
        if (!defaultRole.Contains(StringConstants.DefaultRole))
        {
            await _userManager.AddToRoleAsync(user, StringConstants.DefaultRole);
        }

        // await _signInManager.SignInAsync(user, isPersistent: false);
        return result;
    }
}