using APILoanProduct.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILoanProduct.Models
{
    public class InterestRate
    {
        [Key] 
        public Guid InterestId {  get; set; }=Guid.NewGuid();
        
        public Interesttype? InterestType { get; set; } // simple interest, compound   

        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal InterestRates { get; set; } // for repayment
        [Range(0, 30, ErrorMessage = "Percentage must be between 0 and 30.")]
        [Column(TypeName = "decimal(5,2)")]

        public decimal DisbursementInterestrate { get; set; } // 0.2 or 0.1 percent of what amount he will recive will be minused
        [Column(TypeName="decimal(8,2)")]
        public double ProcessingFee { get; set; }
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
        public double PenaltyRate { get; set; } // penalty percentage or amount 

        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public LoanProduct? LoanProduct { get; set; }

    }
}
