using APILoanProduct.DTO.LoanApplications;
using APILoanProduct.Models.Roles;
using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.Roles
{
    public class RoleMasterReadDto
    {
        public int RoleId { get; set; }
        public RoleTypes RoleName { get; set; }
    }
    public class RoleMasterCreateDto
    {
        [Required]
        public RoleTypesDto RoleName { get; set; }
    }
    public class RoleMasterUpdateDto
    {
        [Required]
        public RoleTypesDto RoleName { get; set; }
    }
}
