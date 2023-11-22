using Core.Models.Account.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Services.Interfaces.Services.Authorization;

public interface IRegisterService
{
    Task<IdentityResult> RegisterUserAsync(RegisterViewModel registerViewModel);
}