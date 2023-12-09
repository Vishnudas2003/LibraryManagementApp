using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Core.Models.Shared;

public class BaseEntity
{
    [Key]
    [Display(Name = "Id")]
    public string Id { get; set; }

    [Display(Name = "Status")]
    public Status Status { get; set; }

    [Display(Name = "Created Date")]
    public DateTime CreatedDateT { get; set; }

    [Display(Name = "Modified Date")]
    public DateTime? ModifiedDateT { get; set; }

    [Display(Name = "Deleted Date")]
    public DateTime? DeletedDateT { get; set; }

    public bool IsDeleted { get; set; } //Soft delete!
}