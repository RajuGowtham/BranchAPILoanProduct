using APILoanProduct.Models.BranchModule;
using APILoanProduct.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILoanProduct.Models
{
    public class ProductAvailability
    {
        [Key]
        public Guid AvailabilityId { get; set; }=Guid.NewGuid();
        
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]// to which branch its avaliable to multiple option select
        public Branch? Branch { get; set; }
        public LoanProductAvaliable? ProductAvailabilityto { get; set; } // group, Individual, client  and for enum no need data anotations

        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]

        public LoanProduct? LoanProduct { get; set; }
    }
}
