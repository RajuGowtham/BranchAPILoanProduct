using APILoanProduct.DTO.LoanProduct;
using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.Branch
{
    public class BranchLoanProductReadDto
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public BranchReadDto? Branch { get; set; }
        public Guid? ProductId { get; set; }
        public LoanProductSummaryDto? LoanProduct { get; set; }
        public DateTime AssignedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class BranchLoanProductCreateDto
    {
        [Required]
        public int BranchId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class BranchLoanProductUpdateDto
    {
        public bool? IsActive { get; set; }
    }
}
