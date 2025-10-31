using APILoanProduct.DTO.Branch;
using APILoanProduct.DTO.LoanApplications;
using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.LoanProduct
{
    public class ProductAvailabilityReadDto
    {
        public Guid AvailabilityId { get; set; }
        public int? BranchId { get; set; }
        public BranchReadDto? Branch { get; set; }
        public LoanProductAvaliableDto? ProductAvailabilityto { get; set; }
        public Guid ProductId { get; set; }
        public LoanProductSummaryDto? LoanProduct { get; set; }
    }



    public class ProductAvailabilityCreateDto
    {
        public string? BranchId { get; set; } // depending on Branch PK type in your DB
        public LoanProductAvaliableDto ProductAvailabilityto { get; set; }
        [Required]
        public Guid ProductId { get; set; }
    }



    public class ProductAvailabilityUpdateDto
    {
        public LoanProductAvaliableDto? ProductAvailabilityto { get; set; }
        public bool? Remove { get; set; }
    }
}
