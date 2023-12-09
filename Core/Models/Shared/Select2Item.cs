namespace Core.Models.Shared;

public class Select2Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    
    public string? Code { get; set; }

    public Select2Item(int id, string name, string? code)
    {
        Id = id;
        Name = name;
        Code = code;
    }
}