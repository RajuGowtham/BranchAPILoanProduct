using APILoanProduct.DTO.Branch;
using APILoanProduct.DTO.LoanApplications;
using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.LoanProduct
{
    public class LoanProductSummaryDto
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public LoanProductCategoryDto? Category { get; set; }
        public bool Status { get; set; }
    }

    public class LoanProductReadDto
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public LoanProductCategoryDto? Category { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProductDescription { get; set; } = default!;
        public InterestRateReadDto? AccountSettings { get; set; } // maybe same as InterestRate
        public LoanAmountDetailsReadDto? LoanAmountDetails { get; set; }
        public InterestRateReadDto? InterestRate { get; set; }
        public RepaymentDetailsReadDto? RepaymentDetails { get; set; }
        public LoanDocumentsReadDto? Documents { get; set; }
        public ProductAvailabilityReadDto? ProductAvailability { get; set; }
        public ICollection<BranchLoanProductReadDto>? BranchLoanProducts { get; set; }
    }



    public class LoanProductCreateDto
    {
        [Required, MaxLength(50)]
        public string ProductName { get; set; } = default!;
        public LoanProductCategoryDto? Category { get; set; }
        [Required, MaxLength(500)]
        public string ProductDescription { get; set; } = default!;
        public InterestRateCreateDto? AccountSettings { get; set; }
        public LoanAmountDetailsCreateDto? LoanAmountDetails { get; set; }
        public InterestRateCreateDto? InterestRate { get; set; }
        public RepaymentDetailsCreateDto? RepaymentDetails { get; set; }
        public LoanDocumentsCreateDto? Documents { get; set; }
        public ProductAvailabilityCreateDto? ProductAvailability { get; set; }
    }


    public class LoanProductUpdateDto
    {
        [MaxLength(50)]
        public string? ProductName { get; set; }
        public LoanProductCategoryDto? Category { get; set; }
        [MaxLength(500)]
        public string? ProductDescription { get; set; }
        public bool? Status { get; set; }
        public InterestRateUpdateDto? AccountSettings { get; set; }
        public LoanAmountDetailsUpdateDto? LoanAmountDetails { get; set; }
        public InterestRateUpdateDto? InterestRate { get; set; }
        public RepaymentDetailsUpdateDto? RepaymentDetails { get; set; }
        public LoanDocumentsUpdateDto? Documents { get; set; }
    }
}
