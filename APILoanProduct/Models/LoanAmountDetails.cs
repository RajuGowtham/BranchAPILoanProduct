using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILoanProduct.Models
{
    public class LoanAmountDetails
    {
        [Key]
        public Guid LoanAmountId { get; set; }=Guid.NewGuid();

        [Column(TypeName ="decimal(18,2)")]
        public decimal MinAmount { get; set; } // for an loan they will give 

        [Column(TypeName ="decimal(18,2)")]
        public decimal MaxAmount { get; set; } // max amount they will give for an loan total amount

        [Column(TypeName ="decimal(18,2)")]
        public decimal DefaultAmount { get; set; } // so in general default amount for an loan 

        [Range(1,15, ErrorMessage ="Maximum no of tranches is 15 and minimum is 1")]
        public int Tranches { get; set; } // tranches means how many times we are splitting the amount

        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public LoanProduct? LoanProduct { get; set; }

    }
}
