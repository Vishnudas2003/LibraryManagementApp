using Core.Models.Account.ViewModels;

namespace Services.Interfaces.Services.Authorization;

public interface ILoginService
{
    Task<LoginViewModel> LoginAsync(LoginViewModel loginViewModel);
    Task LogoutAsync();
}