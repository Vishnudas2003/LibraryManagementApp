using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.LoanManagement;

namespace Core.Models.Catalog;

public class Book
{
    [Key]
    public string Id { get; set; }
    public string Isbn { get; set; } // International Standard Book Number, unique to each edition.
    public string Title { get; set; }
    public DateTime PublicationDateT { get; set; }
    public int Quantity { get; set; }
    
    // Link Id's
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
    public int GenreId { get; set; }
    
    // Linked
    [ForeignKey("GenreId")]
    public Genre Genre { get; set; }
    
    [ForeignKey("AuthorId")]
    public Author Author { get; set; }
    
    [ForeignKey("PublisherId")]
    public Publisher Publisher { get; set; }
    
    // Collection
    public ICollection<Loan> Loans { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}