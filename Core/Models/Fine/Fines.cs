using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;
using Core.Models.Account;
using Core.Models.LoanManagement;

namespace Core.Models.Fine;

public class Fines
{
    [Key]
    public string Id { get; set; }
    public string FineDateT { get; set; }
    public decimal Amount { get; set; }
    public FineStatus Status { get; set; }
    
    // Link Id's
    public string LoanId { get; set; }
    public string ApplicationUserId { get; set; }

    // Linked
    [ForeignKey("LoanId")]
    public Loan Loan { get; set; }
    
    [ForeignKey("ApplicationUserId")]
    public ApplicationUser ApplicationUser { get; set; }
}