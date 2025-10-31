using APILoanProduct.Data;
using APILoanProduct.Interfaces;
using APILoanProduct.Models.BranchModule;
using Microsoft.EntityFrameworkCore;

namespace APILoanProduct.Repository
{
    public class BranchRepository : GenericRepository<Branch, int>, IBranchRepository
    {
        private readonly Context _context;

        public BranchRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Branch>> SearchBranchesAsync(string? name)
        {
            return await _context.Branches
                .Where(b => string.IsNullOrEmpty(name) || b.BranchName.Contains(name))
                .ToListAsync();
        }

        public async Task<IEnumerable<Branch>> FilterBranchesAsync(string? location)
        {
            return await _context.Branches
                .Where(b => string.IsNullOrEmpty(location) || b.BranchLocation.Contains(location))
                .ToListAsync();
        }

        public async Task AssignProductAsync(int branchId, Guid productId)
        {
            if (await _context.BranchLoanProducts.AnyAsync(x => x.BranchId == branchId && x.ProductId == productId))
                throw new Exception("Product already assigned to branch.");

            var mapping = new BranchLoanProduct
            {
                BranchId = branchId,
                ProductId = productId
            };

            _context.BranchLoanProducts.Add(mapping);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProductAsync(int branchId, Guid productId)
        {
            var mapping = await _context.BranchLoanProducts
                .FirstOrDefaultAsync(x => x.BranchId == branchId && x.ProductId == productId);

            if (mapping == null)
                throw new Exception("Mapping not found.");

            _context.BranchLoanProducts.Remove(mapping);
            await _context.SaveChangesAsync();
        }

        public async Task DeactivateProductAsync(int branchId, Guid productId)
        {
            var mapping = await _context.BranchLoanProducts
                .Include(blp => blp.LoanProduct)
                .FirstOrDefaultAsync(x => x.BranchId == branchId && x.ProductId == productId);

            if (mapping == null)
                throw new Exception("Product not assigned to this branch.");

            mapping.LoanProduct.Status = false;
            _context.LoanProducts.Update(mapping.LoanProduct);
            await _context.SaveChangesAsync();
        }
    }

    }
