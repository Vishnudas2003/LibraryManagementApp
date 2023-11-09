using System.ComponentModel.DataAnnotations;

namespace Core.Models.Catalog;

public class Author
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    // Collection
    public ICollection<Book> Books { get; set; }
}