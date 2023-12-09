using System.ComponentModel.DataAnnotations;

namespace Core.Models.Catalog;

public class Genre
{
    [Key]
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // Collection
    public ICollection<Book> Books { get; set; }
}