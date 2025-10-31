using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.LoanProduct
{
    public class LoanAmountDetailsReadDto
    {
        public Guid? LoanAmountId { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public decimal DefaultAmount { get; set; }
        public int Tranches { get; set; }
        public Guid ProductId { get; set; }
    }

    public class LoanAmountDetailsCreateDto
    {
        [Range(0, double.MaxValue)]
        public decimal MinAmount { get; set; }
        [Range(0, double.MaxValue)]
        public decimal MaxAmount { get; set; }
        [Range(0, double.MaxValue)]
        public decimal DefaultAmount { get; set; }
        [Range(1, 15)]
        public int Tranches { get; set; }
    }



    public class LoanAmountDetailsUpdateDto : LoanAmountDetailsCreateDto { }

}
