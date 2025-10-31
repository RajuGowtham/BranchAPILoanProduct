using APILoanProduct.Data;
using APILoanProduct.DTO.Branch;
using APILoanProduct.Interfaces;
using APILoanProduct.Models.BranchModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APILoanProduct.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        // POST: Add new branch
        [HttpPost]
        public async Task<IActionResult> CreateBranch([FromBody] BranchCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var created = await _branchService.AddBranchAsync(dto);
                return CreatedAtAction(nameof(GetBranchById), new { id = created.BranchId }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // GET: get all branches
        [HttpGet]
        public async Task<IActionResult> GetAllBranches()
        {
            var branches = await _branchService.GetAllBranchesAsync();
            return Ok(branches);
        }

        // GET: get branch by id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBranchById(int id)
        {
            var branch = await _branchService.GetBranchByIdAsync(id);
            if (branch == null) return NotFound(new { message = $"Branch with id {id} not found." });
            return Ok(branch);
        }

        // PUT: update branch
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBranch(int id, [FromBody] BranchUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var updated = await _branchService.UpdateBranchAsync(id, dto);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Branch with id {id} not found." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: delete branch
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            try
            {
                var deleted = await _branchService.DeleteBranchAsync(id);
                if (!deleted) return NotFound(new { message = $"Branch with id {id} not found." });
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // GET: search by name
        [HttpGet("search")]
        public async Task<IActionResult> SearchBranches([FromQuery] string? name)
        {
            var results = await _branchService.SearchBranchesAsync(name);
            return Ok(results);
        }

        // GET: filter based on location
        [HttpGet("filter")]
        public async Task<IActionResult> FilterBranches([FromQuery] string? location)
        {
            var results = await _branchService.FilterBranchesAsync(location);
            return Ok(results);
        }

        // POST: Assign product to branch
        [HttpPost("{branchId:int}/assign-product/{productId:guid}")]
        public async Task<IActionResult> AssignProductToBranch(int branchId, Guid productId)
        {
            try
            {
                await _branchService.AssignProductAsync(branchId, productId);
                return Ok(new { message = $"Product {productId} assigned to branch {branchId}." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: Delete product from branch
        [HttpDelete("{branchId:int}/remove-product/{productId:guid}")]
        public async Task<IActionResult> RemoveProductFromBranch(int branchId, Guid productId)
        {
            try
            {
                await _branchService.RemoveProductAsync(branchId, productId);
                return Ok(new { message = $"Product {productId} removed from branch {branchId}." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: deactivate product for branch
        [HttpPut("{branchId:int}/deactivate-product/{productId:guid}")]
        public async Task<IActionResult> DeactivateProduct(int branchId, Guid productId)
        {
            try
            {
                await _branchService.DeactivateProductAsync(branchId, productId);
                return Ok(new { message = $"Product {productId} deactivated for branch {branchId}." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
