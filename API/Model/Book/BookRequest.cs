namespace API.Model.Book;

public class BookRequest
{
    public string? Isbn { get; set; } // International Standard Book Number, unique to each edition.
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? PublicationDate { get; set; }
    public int Quantity { get; set; }
    public string? Genre { get; set; }
    public string?[] Author { get; set; }
    public string? Publisher { get; set; }
    public int? PageCount { get; set; }
    public string? PrintType { get; set; }
}