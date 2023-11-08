using Core.Models.Account.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

public class AccountController : Controller
{
    private readonly ILoginService _loginService;
    private readonly IRegisterService _registerService;
    
    public AccountController(ILoginService loginService, IRegisterService registerService)
    {
        _loginService = loginService;
        _registerService = registerService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Register()
    {
        return View();
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        return View();
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
        var login = await _loginService.LoginAsync(loginViewModel);

        if (login.IsLoginSuccessful)
        {
            return RedirectToAction("Index", "Home");
        }
        
        return View(login);
    }
    
    public async Task<IActionResult> Logout()
    {
        await _loginService.LogoutAsync();
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

        return RedirectToAction("Index", "Home");
    }
}