using APILoanProduct.Models.BranchModule;
using APILoanProduct.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILoanProduct.Models.LoanApplications
{
    public class LoanApplication
    {
        [Key]
        public Guid ApplicationId { get; set; }=Guid.NewGuid();

        // FK to User (Applicant)
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public UserMaster? User { get; set; }

        // FK to Branch
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch? Branch { get; set; }

        //// FK to Loan Product
        //public string? ProductId { get; set; }
        //[ForeignKey("ProductId")]
        //public LoanProduct? LoanProduct { get; set; }

        [Range(1000, 1000000000, ErrorMessage = "Requested amount must be at least 1,000.")]
        [Column(TypeName = "decimal(18,2)")]

        public decimal RequestedAmount { get; set; }

        [Range(1, 360, ErrorMessage = "Tenure must be between 1 and 360 months.")]
        public int TenureYears { get; set; }

        [StringLength(100,MinimumLength =3, ErrorMessage = "Purpose cannot exceed 100 characters.")]
        public string? Purpose { get; set; }  // e.g., Education, Home, Car

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public DateTime AppliedDate { get; set; } = DateTime.Now;
    }

}
