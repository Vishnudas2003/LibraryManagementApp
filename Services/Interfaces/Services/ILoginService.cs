using Core.Models.Account.ViewModels;

namespace Services.Interfaces.Services;

public interface ILoginService
{
    Task<LoginViewModel> LoginAsync(LoginViewModel loginViewModel);
    Task LogoutAsync();
}