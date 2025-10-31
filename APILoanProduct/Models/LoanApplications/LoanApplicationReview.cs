using APILoanProduct.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILoanProduct.Models.LoanApplications
{
    public class LoanApplicationReview
    {
        [Key]
        public Guid ReviewId { get; set; }= Guid.NewGuid();

        public Guid ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public LoanApplication? LoanApplication { get; set; }

        // Manager reviewing
        public Guid ManagerUserId { get; set; }
        [ForeignKey("ManagerUserId")]
        public UserMaster? BranchManager { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime ReviewDate { get; set; } = DateTime.Now;
        // Workflow
        public Loanapplicationstatus? Status { get; set; } = Loanapplicationstatus.Pending; // Pending, UnderReview, Approved, Rejected
        [StringLength(250,MinimumLength =10)]
        public string? Remarks { get; set; }
    }
}
