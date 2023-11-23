namespace Core.Models.Catalog.VM;

public class CatalogViewModel
{
    public List<Book> Books { get; set; }
    public BookFilter BookFilter { get; set; }
    public bool IsEmployee { get; set; }
}