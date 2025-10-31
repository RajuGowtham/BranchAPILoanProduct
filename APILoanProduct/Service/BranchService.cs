using APILoanProduct.DTO.Branch;
using APILoanProduct.Interfaces;
using APILoanProduct.Models.BranchModule;
using AutoMapper;

namespace APILoanProduct.Service
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public BranchService(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BranchReadDto>> GetAllBranchesAsync()
        {
            var branches = await _branchRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BranchReadDto>>(branches);
        }

        public async Task<BranchReadDto?> GetBranchByIdAsync(int branchId)
        {
            var branch = await _branchRepository.GetByIdAsync(branchId);
            return branch == null ? null : _mapper.Map<BranchReadDto>(branch);
        }

        public async Task<BranchReadDto> AddBranchAsync(BranchCreateDto dto)
        {
            var existingBranches = await _branchRepository.GetAllAsync();
            var managerExists = existingBranches.Any(b => b.ManagerUserId == dto.ManagerUserId);

            if (managerExists)
                throw new InvalidOperationException($"Manager (ID: {dto.ManagerUserId}) is already assigned to another branch.");

            var entity = _mapper.Map<Branch>(dto);
            var created = await _branchRepository.AddAsync(entity);
            return _mapper.Map<BranchReadDto>(created);
        }

        public async Task<BranchReadDto> UpdateBranchAsync(int branchId, BranchUpdateDto dto)
        {
            var existing = await _branchRepository.GetByIdAsync(branchId);
            if (existing == null) throw new KeyNotFoundException("Branch not found.");

            if (dto.ManagerUserId != Guid.Empty)
            {
                var allBranches = await _branchRepository.GetAllAsync();
                var managerUsedElsewhere = allBranches.Any(b => b.ManagerUserId == dto.ManagerUserId && b.BranchId != branchId);

                if (managerUsedElsewhere)
                    throw new InvalidOperationException($"Manager (ID: {dto.ManagerUserId}) is already assigned to another branch.");
            }

            _mapper.Map(dto, existing);
            var updated = await _branchRepository.UpdateAsync(branchId, existing);
            return _mapper.Map<BranchReadDto>(updated);
        }

        public async Task<bool> DeleteBranchAsync(int branchId)
        {
            return await _branchRepository.DeleteAsync(branchId);
        }

        public async Task<IEnumerable<BranchReadDto>> SearchBranchesAsync(string? name)
        {
            var results = await _branchRepository.SearchBranchesAsync(name);
            return _mapper.Map<IEnumerable<BranchReadDto>>(results);
        }

        public async Task<IEnumerable<BranchReadDto>> FilterBranchesAsync(string? location)
        {
            var results = await _branchRepository.FilterBranchesAsync(location);
            return _mapper.Map<IEnumerable<BranchReadDto>>(results);
        }

        public async Task AssignProductAsync(int branchId, Guid productId)
        {
            await _branchRepository.AssignProductAsync(branchId, productId);
        }

        public async Task RemoveProductAsync(int branchId, Guid productId)
        {
            await _branchRepository.RemoveProductAsync(branchId, productId);
        }

        public async Task DeactivateProductAsync(int branchId, Guid productId)
        {
            await _branchRepository.DeactivateProductAsync(branchId, productId);
        }
    }
}
