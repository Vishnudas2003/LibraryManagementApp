using System.Security.Claims;
using Core.Models.Account.VM;

namespace Services.Interface.Service.Authorization;

public interface IProfileService
{
    Task<ProfileViewModel> GetProfileDetailsAsync(ClaimsPrincipal claimsPrincipal);
}