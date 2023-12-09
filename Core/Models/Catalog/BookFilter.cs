namespace Core.Models.Catalog;

public class BookFilter
{
    public string? Isbn { get; set; }
    public string? Title { get; set; }
    public DateTime? PublicationStartDateT { get; set; }
    public DateTime? PublicationEndDateT { get; set; }
    public int? Quantity { get; set; }
    public string? AuthorName { get; set; }
    public string? Publisher { get; set; }
    public int? GenreId { get; set; }
    public List<Genre> Genres { get; set; }
}