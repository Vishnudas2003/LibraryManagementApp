using System.Security.Claims;

namespace Services.Interfaces.Services.Authorization;

public interface IAuthorizationService
{
    bool IsLibraryStaff(ClaimsPrincipal claimsPrincipal);
    bool IsSignedIn(ClaimsPrincipal claimsPrincipal);
}