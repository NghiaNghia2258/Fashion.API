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

        [HttpPost]
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

        [HttpPut]
        public async Task<IActionResult> Update(ProductGetByIdDto update)
        {
            await _authoziRepository.IsAuthozi(HttpContext, role: FunctionsDefault.Create_Product);

                bool isSuccess = await _writeSideRepository.UpdateAsync(
                update,
                TokenHelper.GetPayloadToken(HttpContext, _configuration)
                );
            return Ok(new ApiSuccessResult<bool>(isSuccess)
            {
                Message = "Update product successfully !!!",
                StatusCode = 200
            });
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]OptionFilter option)
        {
            IEnumerable<ProductDto> products = await _readSideRepository.FindAll(option);
            return Ok(new ApiSuccessResult<IEnumerable<ProductDto>>(products)
            {
                Message = $"Get success {products.Count()} products",
                StatusCode = 200
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ProductGetByIdDto product = await _readSideRepository.FindById(id);
            return Ok(new ApiSuccessResult<ProductGetByIdDto>(product)
            {
                Message = $"Get success",
                StatusCode = 200
            });
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _authoziRepository.IsAuthozi(HttpContext, role: FunctionsDefault.Create_Product);

            bool res = await _writeSideRepository.DeleteAsync(id,TokenHelper.GetPayloadToken(HttpContext, _configuration));
            if(res){
                return Ok(new ApiSuccessResult<bool>(true)
                            {
                                Message = $"Get success",
                                StatusCode = 200
                            });
            }else{
                return BadRequest(new ApiErrorResult()
                            {
                                Message = $"Get success",
                                StatusCode = 500
                            });
            }
            
        }
    }
}
