using Core.Constants;
using Core.Models.Account;
using Core.Models.Account.ViewModels;
using Core.Models.Shared;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces.Services;
using Services.Interfaces.Services.Authorization;

namespace Services.Services.Authorization;

public class LoginService : ILoginService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    
    public LoginService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    
    public async Task<LoginViewModel> LoginAsync(LoginViewModel loginViewModel)
    {
        var user = await _userManager.FindByNameAsync(loginViewModel.UsernameOrEmail) 
                   ?? await _userManager.FindByEmailAsync(loginViewModel.UsernameOrEmail);
        
        if (user == null || !await _userManager.CheckPasswordAsync(user, loginViewModel.Password))
        {
            return new LoginViewModel
            {
                IsLoginSuccessful = false,
                AlertViewModel = new AlertViewModel
                {
                    Message = StringConstants.LoginFailure
                }
            };
        }

        if (!user.EmailConfirmed)
        {
            return new LoginViewModel
            {
                IsLoginSuccessful = false,
                AlertViewModel = new AlertViewModel
                {
                    Message = StringConstants.VerifyEmail
                }
            };
        }

        await _signInManager.SignInAsync(user, loginViewModel.RememberMe);

        return new LoginViewModel { IsLoginSuccessful = true };
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}