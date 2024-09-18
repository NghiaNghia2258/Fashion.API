using Fashion.Domain.Entities;
using Fashion.Domain.Abstractions.Repositories.Identity;
using Fashion.Domain.Abstractions.Repositories.ReadSide;
using Fashion.Domain.Abstractions.Repositories.WriteSide;
using Fashion.Domain.ApiResult;
using Fashion.Domain.Consts;
using Fashion.Domain.DTOs.Entities.Product;
using Fashion.Domain.Helpers;
using Fashion.Domain.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductWriteSideRepository _writeSideRepository;
        private IProductReadSideRepository _readSideRepository;
        private IAuthoziRepository _authoziRepository;
        private IConfiguration _configuration;

        public ProductController(IProductReadSideRepository readSideRepository, IProductWriteSideRepository writeSideRepository, IAuthoziRepository authoziRepository, IConfiguration configuration)
        {
            _writeSideRepository = writeSideRepository;
            _readSideRepository = readSideRepository;
            _authoziRepository = authoziRepository;
            _configuration = configuration;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProductDto productDto)
        {
            await _authoziRepository.IsAuthozi(HttpContext,role:FunctionsDefault.Create_Product);

            Guid newId = await _writeSideRepository.CreateAsync(
                productDto,
                TokenHelper.GetPayloadToken(HttpContext,_configuration)
                );
            return Ok(new ApiSuccessResult<Guid>(newId) {
                Message = "Create new product successfully !!!",
                StatusCode = 200
            });
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery]PagingRequestParameters paging)
        {
            IEnumerable<ProductDto> products = await _readSideRepository.FindAll(paging);
            return Ok(new ApiSuccessResult<IEnumerable<ProductDto>>(products)
            {
                Message = $"Get success {products.Count()} products",
                StatusCode = 200
            });
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            Product product = await _readSideRepository.FindById(id);
            return Ok(new ApiSuccessResult<Product>(product)
            {
                Message = $"Get success",
                StatusCode = 200
            });
        }
    }
}
