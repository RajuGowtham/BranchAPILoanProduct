using APILoanProduct.DTO.LoanApplications;
using APILoanProduct.DTO.Roles;
using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.Branch
{
    public class BranchReadDto
    {
        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? BranchIFSCcode { get; set; }
        public string? BranchLocation { get; set; }
        public Guid ManagerUserId { get; set; }
        public UserMasterReadDto? BranchManager { get; set; }
        public ICollection<BranchLoanProductReadDto>? BranchLoanProducts { get; set; }
        public ICollection<LoanApplicationSummaryDto>? Loan_Application { get; set; }
    }


    public class BranchCreateDto
    {
        [Required, MaxLength(50)]
        public string BranchName { get; set; } = default!;
        [MaxLength(50)]
        public string? BranchIFSCcode { get; set; }
        [MaxLength(30)]
        public string? BranchLocation { get; set; }
        [Required]
        public Guid ManagerUserId { get; set; }
    }



    public class BranchUpdateDto
    {
        [MaxLength(50)]
        public string? BranchName { get; set; }
        [MaxLength(50)]
        public string? BranchIFSCcode { get; set; }
        [MaxLength(30)]
        public string? BranchLocation { get; set; }
        public Guid ManagerUserId { get; set; }
    }


    public class BranchSummaryDto
    {
        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? BranchLocation { get; set; }
    }
}
