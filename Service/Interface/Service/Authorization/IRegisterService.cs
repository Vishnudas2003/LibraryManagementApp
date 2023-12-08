using Core.Models.Account.VM;
using Microsoft.AspNetCore.Identity;

namespace Services.Interface.Service.Authorization;

public interface IRegisterService
{
    Task<IdentityResult> RegisterUserAsync(RegisterViewModel registerViewModel);
}