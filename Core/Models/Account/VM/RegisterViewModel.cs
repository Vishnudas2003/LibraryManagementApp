using System.ComponentModel.DataAnnotations;
using Core.Models.Shared;

namespace Core.Models.Account.VM;

public class RegisterViewModel
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    public AlertViewModel AlertViewModel { get; set; } = new ();
}