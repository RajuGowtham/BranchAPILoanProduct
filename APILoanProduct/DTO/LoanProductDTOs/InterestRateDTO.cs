using APILoanProduct.DTO.LoanApplications;
using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.LoanProduct
{
    public class InterestRateReadDto
    {
        public Guid InterestId { get; set; }
        public InteresttypeDto? InterestType { get; set; }
        public decimal InterestRates { get; set; }
        public decimal DisbursementInterestrate { get; set; }
        public double ProcessingFee { get; set; }
        public double PenaltyRate { get; set; }
        public Guid ProductId { get; set; }
    }

    public class InterestRateCreateDto
    {
        public InteresttypeDto? InterestType { get; set; }
        [Range(0, 100)]
        public decimal InterestRates { get; set; }
        [Range(0, 30)]
        public decimal DisbursementInterestrate { get; set; }
        public double ProcessingFee { get; set; }
        [Range(0, 100)]
        public double PenaltyRate { get; set; }
    }



    public class InterestRateUpdateDto : InterestRateCreateDto
    {
        // re-use create fields; all optional in update scenario if you prefer
    }
}
