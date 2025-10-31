using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.LoanProduct
{
    public class RepaymentDetailsReadDto
    {
        public Guid RepaymentId { get; set; }
        public string? Frequency { get; set; }
        public int MinimumTenure { get; set; } // years
        public int MaximumTenure { get; set; } // years
        public int GracePerioddays { get; set; }
        public Guid ProductId { get; set; }
    }


    public class RepaymentDetailsCreateDto
    {
        public string? Frequency { get; set; }
        [Range(1, 30)]
        public int MinimumTenure { get; set; }
        [Range(1, 30)]
        public int MaximumTenure { get; set; }
        [Range(1, 180)]
        public int GracePerioddays { get; set; }
    }

    public class RepaymentDetailsUpdateDto : RepaymentDetailsCreateDto { }

}
