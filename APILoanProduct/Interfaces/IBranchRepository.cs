using APILoanProduct.Models.BranchModule;

namespace APILoanProduct.Interfaces
{
    public interface IBranchRepository : IGenericRepository<Branch, int>
    {
        // 🔍 Search branch by name
        Task<IEnumerable<Branch>> SearchBranchesAsync(string? name);

        // 🔎 Filter branch by location
        Task<IEnumerable<Branch>> FilterBranchesAsync(string? location);

        // 🔗 Assign a product to a branch (Many-to-Many)
        Task AssignProductAsync(int branchId, Guid productId);

        // ❌ Remove a product from branch
        Task RemoveProductAsync(int branchId, Guid productId);

        // ⚙️ Deactivate a loan product (set status = false)
        Task DeactivateProductAsync(int branchId, Guid productId);
    }
}
