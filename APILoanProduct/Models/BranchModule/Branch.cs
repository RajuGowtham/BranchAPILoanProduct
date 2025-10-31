using APILoanProduct.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APILoanProduct.Models.LoanApplications;

namespace APILoanProduct.Models.BranchModule
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [MaxLength(50)]
        public string? BranchName { get; set; }
        [MaxLength(50)]
        public string? BranchIFSCcode {  get; set; }
        [MaxLength(30)]
        public string? BranchLocation { get; set; }
        // Manager is a User with Role = BranchManager
        public Guid ManagerUserId { get; set; }
        [ForeignKey("ManagerUserId")]
        public UserMaster? BranchManager { get; set; }
        public ICollection<BranchLoanProduct>? BranchLoanProducts { get; set; }
        public ICollection<LoanApplication>? Loan_Application {  get; set; }
    }
}
