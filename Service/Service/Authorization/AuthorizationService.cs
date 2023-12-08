using System.Security.Claims;
using Core.Enums;
using Core.Models.Account;
using Microsoft.AspNetCore.Identity;
using Services.Interface.Service.Authorization;

namespace Services.Service.Authorization;

public class AuthorizationService(SignInManager<ApplicationUser> signInManager) : IAuthorizationService
{
    public bool IsSignedIn(ClaimsPrincipal claimsPrincipal)
    {
        return signInManager.IsSignedIn(claimsPrincipal);
    }

    public bool IsLibraryStaff(ClaimsPrincipal claimsPrincipal)
    {
        ArgumentNullException.ThrowIfNull(claimsPrincipal);

        return claimsPrincipal.IsInRole(UserRoles.Librarian.ToString()) ||
               claimsPrincipal.IsInRole(UserRoles.AssistantLibrarian.ToString()) ||
               claimsPrincipal.IsInRole(UserRoles.Administrator.ToString());
    }
}