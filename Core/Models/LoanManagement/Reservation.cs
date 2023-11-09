using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;
using Core.Models.Account;
using Core.Models.Catalog;

namespace Core.Models.LoanManagement;

public class Reservation
{
    [Key]
    public string Id { get; set; }
    public string ReservationDateT { get; set; }
    public BookStatus Status { get; set; }
    
    // Link Id's
    public string BookId { get; set; }
    public string ApplicationUserId { get; set; }

    // Linked
    [ForeignKey("BookId")]
    public Book Book { get; set; }
    
    [ForeignKey("ApplicationUserId")]
    public ApplicationUser ApplicationUser { get; set; }
}