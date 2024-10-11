using Fashion.Domain.Abstractions.Repositories.Identity;
using Fashion.Domain.Abstractions.Repositories.ReadSide;
using Fashion.Domain.Abstractions.Repositories.WriteSide;
using Fashion.Domain.ApiResult;
using Fashion.Domain.Consts;
using Fashion.Domain.DTOs.Entities.Customer;
using Fashion.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerWriteSideRepository _writeSideRepository;
        private ICustomerReadSideRepository _readSideRepository;
        private IAuthoziRepository _authoziRepository;
        private IConfiguration _configuration;

        public CustomerController(ICustomerWriteSideRepository writeSideRepository, ICustomerReadSideRepository readSideRepository, IAuthoziRepository authoziRepository, IConfiguration configuration)
        {
            _writeSideRepository = writeSideRepository;
            _readSideRepository = readSideRepository;
            _authoziRepository = authoziRepository;
            _configuration = configuration;
        }
        [HttpGet("filter-include-spending")]
        public async Task<IActionResult> FilterIncludeSpending([FromQuery] OptionFilter option)
        {
            var res = await _readSideRepository.FilterIncludeSpending(option);
            return Ok(new ApiSuccessResult<IEnumerable<CustomerDto>>(res)
            {
                Message = $"Get successfully {res.Count()} customer",
                TotalRecordsCount = CustomerDto.TotalRecordsCountotal
            });
        }
        [HttpGet]
        public async Task<IActionResult> Filter([FromQuery] OptionFilter option)
        {
            var res = await _readSideRepository.Filter(option);
            return Ok(new ApiSuccessResult<IEnumerable<CustomerDto>>(res)
            {
                Message = $"Get successfully {res.Count()} customer",
                TotalRecordsCount = CustomerDto.TotalRecordsCountotal
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            var res = await _readSideRepository.FindById(id);
            return Ok(new ApiSuccessResult<CustomerGetById>(res)
            {
                Message = $"Get successfully cusstomer id {id}"
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await _readSideRepository.FindById(id);
            return Ok(new ApiSuccessResult<CustomerGetById>(res)
            {
                Message = "Delete customer successfully !!!"
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDto obj)
        {

            await _authoziRepository.IsAuthozi(HttpContext, role: FunctionsDefault.Create_Product);

            await _writeSideRepository.Create(obj, TokenHelper.GetPayloadToken(HttpContext, _configuration));
            return Ok(new ApiSuccessResult()
            {

            });
        }
        [HttpPut]
        public async Task<IActionResult> Update(CustomerGetById obj)
        {
            await _authoziRepository.IsAuthozi(HttpContext, role: FunctionsDefault.Create_Product);

            await _writeSideRepository.Update(obj, TokenHelper.GetPayloadToken(HttpContext, _configuration));
            return Ok(new ApiSuccessResult()
            {

            });
        }
    }
}
