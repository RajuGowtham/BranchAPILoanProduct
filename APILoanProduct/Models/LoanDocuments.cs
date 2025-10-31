using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILoanProduct.Models
{
    public class LoanDocuments
    {
        [Key]
        public Guid DocumentId { get; set; }=Guid.NewGuid();
        [MaxLength(200)]
        public string? AddressProof { get; set; }

        [MaxLength(200)]
        public string? IncomeProof { get; set; }

        [MaxLength(200)]
        public string? IdentityProof { get; set; } 

        [MaxLength(500,ErrorMessage ="Maximum of document character reached 500")]
        public string? AdditionalDocuments { get; set; }

        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public LoanProduct? LoanProduct { get; set; }

    }
}
