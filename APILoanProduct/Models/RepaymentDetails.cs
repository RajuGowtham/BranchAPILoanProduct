using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILoanProduct.Models
{
    public class RepaymentDetails
    {
        [Key]
        public Guid RepaymentId { get; set; } = Guid.NewGuid();

        public string? Frequency { get; set; } // Installments timeline 1 month or 2 month once payment
        [Range(1, 30)]
        public int MinimumTenure { get; set; } // time period for repayment in years
        [Range(1, 30)]
        public int MaximumTenure { get; set; }  // 
        [Range(1, 180, ErrorMessage ="180 days is the maximum buffer time")]
        public int GracePerioddays { get; set; } //no of days for buffer time
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public LoanProduct? LoanProduct { get; set; }

    }
}