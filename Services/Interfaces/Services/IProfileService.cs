using System.Security.Claims;
using Core.Models.Account.ViewModels;

namespace Services.Interfaces.Services;

public interface IProfileService
{
    Task<ProfileViewModel> GetProfileDetailsAsync(ClaimsPrincipal claimsPrincipal);
}