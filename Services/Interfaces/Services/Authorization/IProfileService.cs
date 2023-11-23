using System.Security.Claims;
using Core.Models.Account.VM;

namespace Services.Interfaces.Services.Authorization;

public interface IProfileService
{
    Task<ProfileViewModel> GetProfileDetailsAsync(ClaimsPrincipal claimsPrincipal);
}