namespace Core.Models.Catalog;

public class BookFilter
{
    public string? Isbn { get; set; }
    public string? Title { get; set; }
    public DateTime? PublicationStartDateT { get; set; }
    public DateTime? PublicationEndDateT { get; set; }
    public int? Quantity { get; set; }
    public string? AuthorFirstName { get; set; }
    public string? AuthorLastName { get; set; }
    public string? Publisher { get; set; }
    public string? Genre { get; set; }
}