using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.LoanApplications
{
    public class LoanDisbursementReadDto
    {
        public Guid DisbursementId { get; set; }
        public Guid ApplicationId { get; set; }
        public LoanApplicationSummaryDto? LoanApplication { get; set; }
        public DateTime DisbursementDate { get; set; }
        public decimal ApprovedAmount { get; set; }
        public string? DisbursementAccount { get; set; }
    }


    public class LoanDisbursementCreateDto
    {
        [Required]
        public Guid ApplicationId { get; set; }
        [Required]
        public decimal ApprovedAmount { get; set; }
        [MaxLength(50)]
        public string? DisbursementAccount { get; set; }
    }
}
