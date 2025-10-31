using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.LoanApplications
{
    public class LoanApplicationDocumentsReadDto
    {
        public Guid DocumentId { get; set; }
        public Guid ApplicationId { get; set; }
        public string DocumentType { get; set; } = default!;
        public string FilePath { get; set; } = default!;
    }

    public class LoanApplicationDocumentsCreateDto
    {
        [Required, MaxLength(200)]
        public string DocumentType { get; set; } = default!;
        [Required, MaxLength(200)]
        public string FilePath { get; set; } = default!;
    }

   
}
