using System.ComponentModel.DataAnnotations;

namespace Core.Models.Catalog;

public class Publisher
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Collection
    public ICollection<Book> Books { get; set; }
}