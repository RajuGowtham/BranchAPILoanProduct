using APILoanProduct.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILoanProduct.Models.LoanApplications
{
    public class LoanApplicantDetails
    {
        [Key]
        public Guid ApplicantDetailsId { get; set; } = Guid.NewGuid();

        // FK to LoanApplication
        public Guid ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public LoanApplication? LoanApplication { get; set; }

        [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [NotMapped]
        public int User_Age {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age)) age--; // adjust if birthday not yet reached
                return age;
            } } 

        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
        public string? Address { get; set; }

        [StringLength(50, ErrorMessage = "Employment status cannot exceed 50 characters.")]
        public Employmentstatus? EmploymentStatus { get; set; } // Salaried, Self-employed, Student

        [Range(10000, double.MaxValue, ErrorMessage = "Annual income must be at least 10,000.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AnnualIncome { get; set; }
    }
}