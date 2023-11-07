using System.ComponentModel.DataAnnotations;

namespace Core.Models.Shared;

public class BaseEntity
{
    [Key]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "Status")]
    public int StatusId { get; set; }

    [Display(Name = "Created Date")]
    public DateTime CreatedDateT { get; set; }

    [Display(Name = "Modified Date")]
    public DateTime? ModifiedDateT { get; set; }

    [Display(Name = "Deleted Date")]
    public DateTime? DeletedDateT { get; set; }

    public bool IsDeleted { get; set; } //Soft delete!
}