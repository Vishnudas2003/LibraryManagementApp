using System.Security.Claims;
using Core.Models.Account;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces.Services.Authorization;

namespace Services.Services.Authorization;

public class AuthorizationService : IAuthorizationService
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthorizationService(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public bool IsEmployee(ClaimsPrincipal claimsPrincipal)
    {
        var isSignedIn = _signInManager.IsSignedIn(claimsPrincipal);

        if (!isSignedIn) return false;
        
        var isLibrarian = claimsPrincipal.IsInRole("Librarian");
        var isAssistantLibrarian = claimsPrincipal.IsInRole("AssistantLibrarian");
        var isAdministrator = claimsPrincipal.IsInRole("Administrator");

        return isLibrarian || isAssistantLibrarian || isAdministrator;

    }
}