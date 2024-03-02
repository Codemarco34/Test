using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class CustomerManager : ICustomerService
{
    private readonly IRepositoryManager _manager;
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;

    public CustomerManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }
    

    public async Task<(IEnumerable<CustomerDto> customer, MetaData metaData)>  GetAllCustomerAsync(CustomerParameters customerParameters,bool trackChanges)
    {
       var customerwithMetadata = await _manager
           .Customer
           .GetAllCustomersAsync(customerParameters,trackChanges);
       var customersdto= _mapper.Map<IEnumerable<CustomerDto>>(customerwithMetadata);
       return (customersdto, customerwithMetadata.MetaData);
    }

    public async Task<CustomerDto> GetOneCustomerByIdAsync(int id, bool trackChanges)
    {
        var customer = await GetOneCustomerByIdCheckExists(id, trackChanges);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<CustomerDto> CreateOneCustomerAsync(CustomerDtoForInsertion customerDto)
    {
        var entity = _mapper.Map<Customer>(customerDto);
        _manager.Customer.CreateOneCustomer(entity);
        await _manager.SaveAsync();
        return _mapper.Map<CustomerDto>(entity);
        
    }
    

    public async Task UpdateOneCustomerAsync(int id, CustomerDto customerDto, bool trackChanges)
    {
        var entity = await GetOneCustomerByIdCheckExists(id, trackChanges);

        entity = _mapper.Map<Customer>(customerDto);
        _manager.Customer.Update(entity);
        await _manager.SaveAsync();
    }
    

    public async Task DeleteOneCustomerAsync (int id, bool trackChanges)
    {

        var entity = await GetOneCustomerByIdCheckExists(id, trackChanges);
        _manager.Customer.DeleteOneCustomer(entity);
        await _manager.SaveAsync();

    }

    public async Task<(CustomerDto customerDto, Customer customer)> GetOneCustomerForPatchAsync (int id, bool trackChanges)
    {
        var customer = await GetOneCustomerByIdCheckExists(id,trackChanges);
        var CustomerDtoForUpdate = _mapper.Map<CustomerDto>(customer);
        return (CustomerDtoForUpdate, customer);
    }

    public async Task SaveChangesForPatchAsync (CustomerDto customerDto, Customer customer)
    {
        _mapper.Map(customerDto, customer);
        await _manager.SaveAsync();
    }


    private async Task<Customer> GetOneCustomerByIdCheckExists(int id, bool trackChanges)
    {
        var entity = await _manager.Customer.GetOneCustomerByIdAsync (id, trackChanges);
        return entity;
    }
    
}