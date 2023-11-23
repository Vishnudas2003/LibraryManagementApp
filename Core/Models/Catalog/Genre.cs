using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Core.Models.Catalog;

public class Genre
{
    [Key]
    public int Id { get; set; }
    public GenreType GenreType { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // Collection
    public ICollection<Book> Books { get; set; }
}