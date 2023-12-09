using Core.Models.Shared;

namespace Core.Models.Catalog.VM;

public class AddBookVm
{
    public string? Isbn { get; set; }
    public int Quantity { get; set; } = 0;

    public AlertViewModel? AlertViewModel { get; set; }

    public Book? Book { get; set; }
}