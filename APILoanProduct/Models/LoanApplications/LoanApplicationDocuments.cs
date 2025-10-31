using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILoanProduct.Models.LoanApplications
{
    public class LoanApplicationDocuments
    {
        [Key]
        public Guid DocumentId { get; set; }=Guid.NewGuid();

        public Guid ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public LoanApplication? LoanApplication { get; set; }

        [Required]
        [MaxLength(200)]
        public string? DocumentType { get; set; } // ID Proof, Address Proof, Salary Slip

        [Required]
        [MaxLength(200)]
        public string? FilePath { get; set; } // location of uploaded file
    }

}
