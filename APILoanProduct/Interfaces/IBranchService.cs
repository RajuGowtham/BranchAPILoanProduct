using APILoanProduct.DTO.Branch;
using APILoanProduct.Models.BranchModule;

namespace APILoanProduct.Interfaces
{
    public interface IBranchService
    {
        Task<IEnumerable<BranchReadDto>> GetAllBranchesAsync();
        Task<BranchReadDto?> GetBranchByIdAsync(int branchId);
        Task<BranchReadDto> AddBranchAsync(BranchCreateDto dto);
        Task<BranchReadDto> UpdateBranchAsync(int branchId, BranchUpdateDto dto);
        Task<bool> DeleteBranchAsync(int branchId);

        Task<IEnumerable<BranchReadDto>> SearchBranchesAsync(string? name);
        Task<IEnumerable<BranchReadDto>> FilterBranchesAsync(string? location);

        Task AssignProductAsync(int branchId, Guid productId);
        Task RemoveProductAsync(int branchId, Guid productId);

        // Deactivate product (set LoanProduct.Status = false)
        Task DeactivateProductAsync(int branchId, Guid productId);

    }
}
