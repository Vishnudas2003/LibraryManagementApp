using System.Security.Claims;
using Core.Enums;
using Core.Models.Account;
using Microsoft.AspNetCore.Identity;
using Services.Interface.Service.Authorization;

namespace Services.Service.Authorization;

public class AuthorizationService : IAuthorizationService
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthorizationService(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public bool IsSignedIn(ClaimsPrincipal claimsPrincipal)
    {
        return _signInManager.IsSignedIn(claimsPrincipal);
    }

    public bool IsLibraryStaff(ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal == null)
        {
            throw new ArgumentNullException(nameof(claimsPrincipal));
        }

        return claimsPrincipal.IsInRole(UserRoles.Librarian.ToString()) ||
               claimsPrincipal.IsInRole(UserRoles.AssistantLibrarian.ToString()) ||
               claimsPrincipal.IsInRole(UserRoles.Administrator.ToString());
    }
}