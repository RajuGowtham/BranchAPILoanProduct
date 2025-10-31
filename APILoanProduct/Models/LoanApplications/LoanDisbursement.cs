using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILoanProduct.Models.LoanApplications
{
    public class LoanDisbursement
    {
        [Key]
        public Guid DisbursementId { get; set; }=Guid.NewGuid();

        public Guid ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public LoanApplication? LoanApplication { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DisbursementDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ApprovedAmount { get; set; }
        [MaxLength(50)]
        public string? DisbursementAccount { get; set; } // sending amount to an different user
    }

}
