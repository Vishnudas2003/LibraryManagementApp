using System.Security.Claims;

namespace Services.Interfaces.Services.Authorization;

public interface IAuthorizationService
{
    bool IsEmployee(ClaimsPrincipal claimsPrincipal);
}