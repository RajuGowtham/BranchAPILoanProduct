using APILoanProduct.DTO.Roles;
using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.LoanApplications
{
    public class LoanApplicationReviewReadDto
    {
        public Guid ReviewId { get; set; }
        public Guid ApplicationId { get; set; }
        public LoanApplicationSummaryDto? LoanApplication { get; set; }
        public Guid ManagerUserId { get; set; }
        public UserMasterReadDto? BranchManager { get; set; }
        public DateTime ReviewDate { get; set; }
        public LoanapplicationstatusDto? Status { get; set; }
        public string? Remarks { get; set; }
    }

    public class LoanApplicationReviewCreateDto
    {
        [Required]
        public Guid ApplicationId { get; set; }
        [Required]
        public Guid ManagerUserId { get; set; }
        public LoanapplicationstatusDto Status { get; set; } = LoanapplicationstatusDto.Pending;
        [StringLength(250, MinimumLength = 10)]
        public string? Remarks { get; set; }
    }


}
