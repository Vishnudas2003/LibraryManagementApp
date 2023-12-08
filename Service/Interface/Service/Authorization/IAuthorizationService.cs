using System.Security.Claims;

namespace Services.Interface.Service.Authorization;

public interface IAuthorizationService
{
    bool IsLibraryStaff(ClaimsPrincipal claimsPrincipal);
    bool IsSignedIn(ClaimsPrincipal claimsPrincipal);
}