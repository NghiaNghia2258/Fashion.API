using Fashion.Domain.Abstractions.Repositories.Identity;
using Fashion.Domain.Abstractions.Repositories.ReadSide;
using Fashion.Domain.Abstractions.Repositories.WriteSide;
using Fashion.Domain.ApiResult;
using Fashion.Domain.Consts;
using Fashion.Domain.DTOs.Entities.Order;
using Fashion.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderWriteSideRepository _writeSideRepository;
        private IOrderReadSideRepository _readSideRepository;
        private IAuthoziRepository _authoziRepository;
        private IConfiguration _configuration;

        public OrderController(IOrderWriteSideRepository writeSideRepository, IOrderReadSideRepository readSideRepository, IAuthoziRepository authoziRepository, IConfiguration configuration)
        {
            _writeSideRepository = writeSideRepository;
            _readSideRepository = readSideRepository;
            _authoziRepository = authoziRepository;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] OptionFilter option)
        {
            var res = await _readSideRepository.Filter(option);
            return Ok(new ApiSuccessResult<IEnumerable<OrderDto>>(res)
            {
                Message = "Get order success"
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            var res = await _readSideRepository.FindById(id);
            return Ok(new ApiSuccessResult<OrderGetByIdDto>(res)
            {
                Message = "Get order success"
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _authoziRepository.IsAuthozi(HttpContext, role: FunctionsDefault.Create_Product);

            var res = await _writeSideRepository.Delete(id, TokenHelper.GetPayloadToken(HttpContext, _configuration));
            return Ok(new ApiSuccessResult<bool>(res)
            {
                Message = "Delete order success"
            });
        }
        [HttpPost("payment/{id}")]
        public async Task<IActionResult> Payment(Guid id)
        {
            await _authoziRepository.IsAuthozi(HttpContext, role: FunctionsDefault.Create_Product);
            await _writeSideRepository.Payment(id, TokenHelper.GetPayloadToken(HttpContext, _configuration));
            return Ok(new ApiSuccessResult());
        }
        [HttpPut]
        public async Task<IActionResult> Update(OrderGetByIdDto obj)
        {
            await _authoziRepository.IsAuthozi(HttpContext, role: FunctionsDefault.Create_Product);

            var res = await _writeSideRepository.Update(obj, TokenHelper.GetPayloadToken(HttpContext, _configuration));
            return Ok(new ApiSuccessResult());
        }
    }
}
