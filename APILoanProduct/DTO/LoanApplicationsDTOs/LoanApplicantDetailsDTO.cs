using APILoanProduct.DTO.Roles;
using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.LoanApplications
{

    #region Enums (repeat from your models)
    public enum RoleTypesDto { Admin, Branch_Manager, User }
    public enum LoanProductCategoryDto { PersonalLoan, BusinessLoan }
    public enum InteresttypeDto { SimpleInterest, CompoundInterest }
    public enum LoanProductAvaliableDto { Group, Client, Individual }
    public enum EmploymentstatusDto { Student, Salaried, SelfEmployed, Freelancer }
    public enum LoanapplicationstatusDto { Pending, UnderReview, Approved, Rejected }
    #endregion
    public class LoanApplicantDetailsReadDto
    {
        public Guid ApplicantDetailsId { get; set; }
        public Guid ApplicationId { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int User_Age { get; set; } // computed
        public string? Address { get; set; }
        public EmploymentstatusDto? EmploymentStatus { get; set; }
        public decimal AnnualIncome { get; set; }
    }

    public class LoanApplicantDetailsCreateDto
    {
        [StringLength(100)]
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(250)]
        public string? Address { get; set; }
        public EmploymentstatusDto? EmploymentStatus { get; set; }
        [Range(10000, double.MaxValue)]
        public decimal AnnualIncome { get; set; }
    }

    
}
