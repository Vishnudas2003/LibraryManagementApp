using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Core.Models.Account;

public class ApplicationUser : IdentityUser
{
    [Display(Name = "Status")]
    public int StatusId { get; set; }

    [Display(Name = "Created Date")]
    public DateTime CreatedDateT { get; set; }

    [Display(Name = "Modified Date")]
    public DateTime? ModifiedDateT { get; set; }
    
    [NotMapped] public string? StatusMessage { get; set; } = string.Empty;
}