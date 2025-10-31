using APILoanProduct.Models.BranchModule;
using System.ComponentModel.DataAnnotations;
using APILoanProduct.Models.Roles;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace APILoanProduct.Models
{
    public class LoanProduct
    {
        [Key]
        public Guid ProductId { get; set; }=Guid.NewGuid();
        [Required]
        [MaxLength(50,ErrorMessage ="Product name cannot exceed above 50 characters ")]
        public string? ProductName { get; set; }
     
        public LoanProductCategory? Category { get; set; } //Personal Loan, Business loan etc

        public bool Status { get; set; } = true; // active, inactive (active = true)

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate {  get; set; } // Auto when created or added

        [Required]
        [MaxLength(500,ErrorMessage ="Product Discription cannot exceed above 500 characters")]
        public string ProductDescription { get; set; }

        // foreign keys navigations

        //public InterestRate? AccountSettings { get; set; }
        public LoanAmountDetails? LoanAmountDetails { get; set; }
        public InterestRate? InterestRate { get; set; }
        public RepaymentDetails? RepaymentDetails { get; set; }
        public LoanDocuments? Documents { get; set; }

        public ProductAvailability? ProductAvailability { get; set; }

        public ICollection<BranchLoanProduct>? BranchLoanProducts { get; set; }



    }
}
