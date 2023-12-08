using Core.Models.Account.VM;

namespace Services.Interface.Service.Authorization;

public interface ILoginService
{
    Task<LoginViewModel> LoginAsync(LoginViewModel loginViewModel);
    Task LogoutAsync();
}