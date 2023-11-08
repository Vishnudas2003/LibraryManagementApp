using Core.Models.Shared;

namespace Core.Models.Account.ViewModels;

public class LoginViewModel
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
    public bool IsLoginSuccessful { get; set; }
    public AlertViewModel AlertViewModel { get; set; } = new ();
}