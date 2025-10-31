using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILoanProduct.Models.BranchModule
{
    public class BranchLoanProduct
    {
        [Key]
        public int BranchLoanProductId { get; set; }
        public int BranchId { get; set; }
        public Branch? Branch { get; set; } 
        public Guid? ProductId { get; set; }
        public LoanProduct? LoanProduct { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime AssignedDate { get; set; }
        public bool IsActive { get; set; } // weather an loan product is avaliable still 
    }
}
