using Fashion.Domain.Abstractions.Repositories.ReadSide;
using Fashion.Domain.ApiResult;
using Fashion.Domain.DTOs.Entities.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private IProductCategoryReadSideRepository _readSideRepository;

        public ProductCategoryController(IProductCategoryReadSideRepository readSideRepository)
        {
            _readSideRepository = readSideRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _readSideRepository.FindAll();
            return Ok(new ApiSuccessResult<IEnumerable<ProductCategoryDto>>(res)
            {
                Message = $"Get category successfully {res.Count()} records",
                FetchedRecordsCount = res.Count()
            });
        }
    }
}
