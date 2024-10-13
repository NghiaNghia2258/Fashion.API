using System.Text;
using AutoMapper;
using Dapper;
using Fashion.Domain;
using Fashion.Domain.Abstractions.Entities;
using Fashion.Domain.Abstractions.Repositories.ReadSide;
using Fashion.Domain.Abstractions.Repositories.WriteSide;
using Fashion.Domain.Consts;
using Fashion.Domain.DTOs.Entities.Customer;
using Fashion.Domain.DTOs.Identity;
using Fashion.Domain.Entities;
using Fashion.Domain.Enum;
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
        var res = await query
        .Skip((option.PageIndex - 1) * option.PageSize).Take(option.PageSize)
        .Select(x => new CustomerDto()
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name,
            Point = x.Point,
            Phone = x.Phone,
            Gender = x.Gender,
            Debt = x.Debt,
            CreatedAt = x.CreatedAt,
            CreatedBy = x.CreatedBy,
            CreatedName = x.CreatedName,
        })
        .ToListAsync();
        return res;
    }
    public async Task<IEnumerable<CustomerDto>> FilterIncludeSpending(OptionFilter option)
    {
        StringBuilder stringBuilder = new StringBuilder();
        if (option.NameOrPhone != null)
        {
            stringBuilder.Append($" and (c.Name + c.Phone) LIKE '%{option.NameOrPhone}%'");
        }
        string stringQuery = @$"
            select c.Id,
            c.Code,
            c.Name,
            c.Point,
            c.Phone,
            c.Gender,
            c.Debt,
            c.CreatedAt,
            c.CreatedBy,
            c.CreatedName,
            sum(o.TotalPrice) as {nameof(CustomerDto.QuarterlySpending)} from Customer c
            left join [Order] o on o.CustomerId = c.Id
            where o.CreatedAt > @ThreeMonthsAgo and c.IsDeleted != 1
            {stringBuilder}
            group by c.Id, c.Name, c.Code, c.Point, c.Phone, c.Gender, c.Debt, c.CreatedAt, c.CreatedBy, c.CreatedName
            ORDER BY c.Id 
            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
        ";
        var parameters = new
        {
            Offset = (option.PageIndex - 1) * option.PageSize,
            option.PageSize,
            TimeConst.ThreeMonthsAgo
        };

        IEnumerable<CustomerDto> result = await _unitOfWork.SqlConnection.QueryAsync<CustomerDto>(stringQuery, parameters);

        return result;
    }

    public async Task<CustomerGetById> FindById(Guid id)
    {
        var res = await GetByIdAsync(id);
        return _mapper.Map<CustomerGetById>(res);
    }

    public async Task<bool> Create(CreateCustomerDto obj, PayloadToken payload)
    {
        Customer newCustomer = _mapper.Map<Customer>(obj);
        await CreateAsync(newCustomer, payload);
        return true;
    }
    public async Task<bool> Update(CustomerGetById obj, PayloadToken payload)
    {
        Customer customer = _mapper.Map<Customer>(obj);
        await UpdateAsync(customer, payload);
        return true;
    }
    public async Task<bool> Delete(Guid id, PayloadToken payload)
    {
        string query = @$"
            UPDATE [Customer] SET
            {nameof(ISoftDelete.IsDeleted)} = @IsDeleted,
            {nameof(ISoftDelete.DeletedAt)} = @DeletedAt,
            {nameof(ISoftDelete.DeletedName)} = @DeletedName,
            {nameof(ISoftDelete.DeletedBy)} = @DeletedBy
            WHERE [Id] = @Id
        ";
        var parameter = new
        {
            Id = id,
            IsDeleted = IsDeleted.True,
            DeletedAt = TimeConst.Now,
            DeletedBy = payload.Username,
            DeletedName = payload.FullName
        };
        object? obj = await _unitOfWork.SqlConnection.ExecuteScalarAsync(query, parameter);
        return true;
    }
}
