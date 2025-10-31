using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.Models.Roles
{
    public class RoleMaster
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public RoleTypes RoleName { get; set; }// "Admin", "BranchManager", "User"

        public ICollection<UserMaster>? Users { get; set; }

        // Role_Name = RoleMaster.Role_Types.Admin so now when in the UI front 
    }
    
}

