namespace Core.Models.Catalog.VM;

public class BookDetailViewModel
{
    public Book? Book { get; set; } = new();
    public bool IsEmployee { get; set; }
}