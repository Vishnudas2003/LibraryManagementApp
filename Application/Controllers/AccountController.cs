using Core.Constants;
using Core.Models.Account.VM;
using Core.Models.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interface.Service.Authorization;

namespace Application.Controllers;

public class AccountController(ILoginService loginService, IRegisterService registerService,
        IProfileService profileService)
    : Controller
{
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        var result = await registerService.RegisterUserAsync(registerViewModel);

        if (result.Succeeded)
        {
            var alertViewModel = new AlertViewModel
            {
                Message = StringConstants.RegisterSuccess,
                IsSuccess = true
            };
            
            return View(nameof(Login), new LoginViewModel { AlertViewModel = alertViewModel });
        }

        registerViewModel.AlertViewModel = new AlertViewModel
        {
            Message = StringConstants.RegisterFailure,
            IsSuccess = false
        };

        return View(registerViewModel);
    }
    
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(AlertViewModel alertViewModel)
    {
        return View(new LoginViewModel { AlertViewModel = alertViewModel });
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        var login = await loginService.LoginAsync(loginViewModel);

        if (login.IsLoginSuccessful)
        {
            return RedirectToAction("Index", "Home");
        }
        
        return View(login);
    }
    
    public async Task<IActionResult> Logout()
    {
        await loginService.LogoutAsync();
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var profileViewModel = await profileService.GetProfileDetailsAsync(User);
        
        return View(profileViewModel);
    }
    
    [HttpPost]
    public IActionResult Profile(ProfileViewModel profileViewModel)
    {
        return View(profileViewModel);
    }
}