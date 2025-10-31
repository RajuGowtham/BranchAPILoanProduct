using APILoanProduct.DTO.Branch;
using APILoanProduct.DTO.Roles;
using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.LoanApplications
{
    public class LoanApplicationSummaryDto
    {
        public Guid ApplicationId { get; set; }
        public Guid? ProductId { get; set; }
        public decimal RequestedAmount { get; set; }
        public int TenureYears { get; set; }
        public string? Purpose { get; set; }
        public DateTime AppliedDate { get; set; }
        public LoanapplicationstatusDto Status { get; set; } // if you keep status in a review entity, adapt accordingly
    }

    public class LoanApplicationReadDto
    {
        public Guid ApplicationId { get; set; }
        public Guid UserId { get; set; }
        public UserMasterReadDto? User { get; set; }
        public int BranchId { get; set; }
        public BranchReadDto? Branch { get; set; }
        public decimal RequestedAmount { get; set; }
        public int TenureYears { get; set; }
        public string? Purpose { get; set; }
        public DateTime AppliedDate { get; set; }
        public ICollection<LoanApplicationDocumentsReadDto>? Documents { get; set; }
        public ICollection<LoanApplicantDetailsReadDto>? ApplicantDetails { get; set; }
        public ICollection<LoanApplicationReviewReadDto>? Reviews { get; set; }
        public LoanDisbursementReadDto? Disbursement { get; set; }
    }



    public class LoanApplicationCreateDto
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public int BranchId { get; set; }
        [Range(1000, 1000000000)]
        public decimal RequestedAmount { get; set; }
        [Range(1, 360)]
        public int TenureYears { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string? Purpose { get; set; }
        public ICollection<LoanApplicationDocumentsCreateDto>? Documents { get; set; }
        public LoanApplicantDetailsCreateDto? ApplicantDetails { get; set; }
    }


    public class LoanApplicationUpdateDto
    {
        public decimal? RequestedAmount { get; set; }
        public int? TenureYears { get; set; }
        public string? Purpose { get; set; }
        // status/update of workflow should happen through review endpoints
    }
}
