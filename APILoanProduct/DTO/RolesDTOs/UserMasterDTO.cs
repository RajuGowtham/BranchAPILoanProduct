using APILoanProduct.DTO.Branch;
using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.Roles
{
    public class UserMasterReadDto
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmailId { get; set; }
        public string? UserPhoneNo { get; set; }
        public decimal? UserBalance { get; set; }
        public int Role_Id { get; set; }
        public RoleMasterReadDto? Role { get; set; } // nested for read
        public ICollection<BranchSummaryDto>? ManagedBranches { get; set; }
    }

    public class UserMasterCreateDto
    {
        [Required, MaxLength(50)]
        public string UserName { get; set; } = default!;
        [Required]
        public string UserPassword { get; set; } = default!; // plain text accepted at API boundary, hash server-side
        [EmailAddress]
        public string? UserEmailId { get; set; }
        public string? UserPhoneNo { get; set; }
        public decimal? UserBalance { get; set; }
        [Required]
        public int Role_Id { get; set; }
    }


    public class UserMasterUpdateDto
    {
        [MaxLength(50)]
        public string? UserName { get; set; }
        public string? UserPassword { get; set; } // optional: if present update hash
        [EmailAddress]
        public string? UserEmailId { get; set; }
        public string? UserPhoneNo { get; set; }
        public decimal? UserBalance { get; set; }
        public int? Role_Id { get; set; }
    }
}
