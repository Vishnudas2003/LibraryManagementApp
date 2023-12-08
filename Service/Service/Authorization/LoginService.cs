using Core.Constants;
using Core.Models.Account;
using Core.Models.Account.VM;
using Core.Models.Shared;
using Microsoft.AspNetCore.Identity;
using Services.Interface.Service.Authorization;

namespace Services.Service.Authorization;

public class LoginService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    : ILoginService
{
    public async Task<LoginViewModel> LoginAsync(LoginViewModel loginViewModel)
    {
        var user = await userManager.FindByNameAsync(loginViewModel.UsernameOrEmail) 
                   ?? await userManager.FindByEmailAsync(loginViewModel.UsernameOrEmail);
        
        if (user == null || !await userManager.CheckPasswordAsync(user, loginViewModel.Password))
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

        await signInManager.SignInAsync(user, loginViewModel.RememberMe);

        return new LoginViewModel { IsLoginSuccessful = true };
    }

    public async Task LogoutAsync()
    {
        await signInManager.SignOutAsync();
    }
}