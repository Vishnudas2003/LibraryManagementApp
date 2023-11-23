using Core.Models.Account.VM;

namespace Services.Interfaces.Services.Authorization;

public interface ILoginService
{
    Task<LoginViewModel> LoginAsync(LoginViewModel loginViewModel);
    Task LogoutAsync();
}