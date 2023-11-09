using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Account;
using Core.Models.Catalog;
using Core.Models.Fine;

namespace Core.Models.LoanManagement;

public class Loan
{
    [Key]
    public string Id { get; set; }
    public DateTime CheckoutDateT { get; set; }
    public DateTime DueDateT { get; set; }
    public DateTime ReturnDateT { get; set; }
    
    // Link Id's
    public string BookId { get; set; }
    public string ApplicationUserId { get; set; }
    
    // Linked
    [ForeignKey("BookId")]
    public Book Book { get; set; }
    
    [ForeignKey("ApplicationUserId")]
    public ApplicationUser ApplicationUser { get; set; }
    
    // Collection
    public Fines Fines { get; set; }
}