using Core.Models.Account.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Services.Interfaces.Services;

public interface IRegisterService
{
    Task<IdentityResult> RegisterUserAsync(RegisterViewModel registerViewModel);
}