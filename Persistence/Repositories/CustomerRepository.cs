using AutoMapper;
using Fashion.Domain;
using Fashion.Domain.Abstractions.Repositories.ReadSide;
using Fashion.Domain.Abstractions.Repositories.WriteSide;
using Fashion.Domain.Consts;
using Fashion.Domain.DTOs.Entities.Customer;
using Fashion.Domain.DTOs.Identity;
using Fashion.Domain.Entities;
using Fashion.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CustomerRepository : RepositoryBase<Customer, Guid>, ICustomerReadSideRepository, ICustomerWriteSideRepository
{
    public CustomerRepository(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    public async Task<IEnumerable<CustomerDto>> Filter(OptionFilter option)
    {
        var query = FindAll().Where(x => x.IsDeleted != true
        && (option.NameOrPhone == null || (x.Name + x.Phone).Contains(option.NameOrPhone))
        );
        CustomerDto.TotalRecordsCountotal = await query.CountAsync();
        var res = await query.Include(x => x.Orders.Where(y => y.CreatedAt >= TimeConst.ThreeMonthsAgo))
        .Skip((option.PageIndex - 1) * option.PageSize).Take(option.PageSize)
        .Select(x => new CustomerDto()
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name,
            Point = x.Point,
            Phone = x.Phone,
            Gender = x.Gender,
            QuarterlySpending = x.Orders.Sum(y => y.TotalPrice),
            Debt = x.Debt,
            CreatedAt = x.CreatedAt,
            CreatedBy = x.CreatedBy,
            CreatedName = x.CreatedName,
        })
        .ToListAsync();
        return res;
    }
    public async Task<CustomerGetById> FindById(Guid id)
    {
        var res = await FindAll().Where(x => x.Id == id).FirstOrDefaultAsync();
        if(res == null)
        {
            throw new NotFoundDataException();
        }
        return _mapper.Map<CustomerGetById>(res);
    }

    public async Task<bool> Create(CreateCustomerDto obj, PayloadToken payload)
    {
        Customer? isExist = await FindAll().Where(x => x.Phone == obj.Phone).FirstOrDefaultAsync();
        if(isExist != null)
        {
            throw new RecordAlreadyExistsException($"Phone already exist");
        }
        Customer newCustomer = _mapper.Map<Customer>(obj);
        await CreateAsync(newCustomer,payload);
        return true;
    }
    public async Task<bool> Update(CustomerGetById obj, PayloadToken payload)
    {
        Customer customer = _mapper.Map<Customer>(obj);
        await UpdateAsync(customer,payload);
        return true;
    }
}
