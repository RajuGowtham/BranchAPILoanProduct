using APILoanProduct.Models.BranchModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILoanProduct.Models.Roles
{
    public class UserMaster
    {
        [Key]
        public Guid UserId { get; set; }=Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$")] 
        public string? UserName { get; set; } // takes only letters no numbers

        public string? UserPasswordHash { get; set; }

        public string? UserEmailId { get; set; }

        public string? UserPhoneNo { get; set; }

        [Column(TypeName = "decimal(18,2)")]

        public Decimal? UserBalance { get; set; }

        // Branch Id
        

        // FK to Role
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RoleMaster? Role { get; set; }
       
        public ICollection<Branch>? ManagedBranches { get; set; }


    }
}
