using System.ComponentModel.DataAnnotations;

namespace APILoanProduct.DTO.LoanProduct
{
    public class LoanDocumentsReadDto
    {
        public Guid DocumentId { get; set; }
        public string? AddressProof { get; set; }
        public string? IncomeProof { get; set; }
        public string? IdentityProof { get; set; }
        public string? AdditionalDocuments { get; set; }
        public Guid ProductId { get; set; }
    }

    public class LoanDocumentsCreateDto
    {
        [MaxLength(200)]
        public string? AddressProof { get; set; }
        [MaxLength(200)]
        public string? IncomeProof { get; set; }
        [MaxLength(200)]
        public string? IdentityProof { get; set; }
        [MaxLength(500)]
        public string? AdditionalDocuments { get; set; }
    }

    public class LoanDocumentsUpdateDto : LoanDocumentsCreateDto { }

}
