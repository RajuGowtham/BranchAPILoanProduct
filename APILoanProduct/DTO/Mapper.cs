using APILoanProduct.DTO.Branch;
using APILoanProduct.DTO.LoanApplications;
using APILoanProduct.DTO.LoanProduct;
using APILoanProduct.DTO.Roles;
using APILoanProduct.DTO;
using APILoanProduct.Models;
using APILoanProduct.Models.BranchModule;
using APILoanProduct.Models.LoanApplications;
using APILoanProduct.Models.Roles;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        // Roles & Users
        CreateMap<RoleMaster, RoleMasterReadDto>();
        CreateMap<RoleMasterCreateDto, RoleMaster>();

        CreateMap<UserMaster, UserMasterReadDto>();
        CreateMap<UserMasterCreateDto, UserMaster>()
            .ForMember(dest => dest.UserPasswordHash, opt => opt.Ignore()); // handle hash in service
        CreateMap<UserMasterUpdateDto, UserMaster>();

        // Branches
        CreateMap<Branch, BranchReadDto>();
        CreateMap<BranchCreateDto, Branch>();
        CreateMap<BranchUpdateDto, Branch>();

        // BranchLoanProduct
        CreateMap<BranchLoanProduct, BranchLoanProductReadDto>();
        CreateMap<BranchLoanProductCreateDto, BranchLoanProduct>();

        // Loan product and sub-entities
        CreateMap<LoanProduct, LoanProductReadDto>();
        CreateMap<LoanProductCreateDto, LoanProduct>();
        CreateMap<LoanProductUpdateDto, LoanProduct>();


        //CreateMap<LoanProduct, LoanProductSummaryDto>();

        CreateMap<InterestRate, InterestRateReadDto>();
        CreateMap<InterestRateCreateDto, InterestRate>();
        CreateMap<InterestRateUpdateDto, InterestRate>();

        CreateMap<LoanAmountDetails, LoanAmountDetailsReadDto>();
        CreateMap<LoanAmountDetailsCreateDto, LoanAmountDetails>();

        CreateMap<LoanDocuments, LoanDocumentsReadDto>();
        CreateMap<LoanDocumentsCreateDto, LoanDocuments>();

        CreateMap<RepaymentDetails, RepaymentDetailsReadDto>();
        CreateMap<RepaymentDetailsCreateDto, RepaymentDetails>();

        CreateMap<ProductAvailability, ProductAvailabilityReadDto>();
        CreateMap<ProductAvailabilityCreateDto, ProductAvailability>();

        // Loan applications
        CreateMap<LoanApplication, LoanApplicationReadDto>();
        CreateMap<LoanApplicationCreateDto, LoanApplication>();
        CreateMap<LoanApplicationUpdateDto, LoanApplication>();

        CreateMap<LoanApplicationDocuments, LoanApplicationDocumentsReadDto>();
        CreateMap<LoanApplicationDocumentsCreateDto, LoanApplicationDocuments>();

        CreateMap<LoanApplicantDetails, LoanApplicantDetailsReadDto>();
        CreateMap<LoanApplicantDetailsCreateDto, LoanApplicantDetails>();

        CreateMap<LoanApplicationReview, LoanApplicationReviewReadDto>();
        CreateMap<LoanApplicationReviewCreateDto, LoanApplicationReview>();

        CreateMap<LoanDisbursement, LoanDisbursementReadDto>();
        CreateMap<LoanDisbursementCreateDto, LoanDisbursement>();
    }
}
