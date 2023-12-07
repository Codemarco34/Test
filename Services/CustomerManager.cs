using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
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
    

    public IEnumerable<CustomerDto> GetAllCustomer(bool trackChanges)
    {
       var customer = _manager.Customer.GetAllCustomers(trackChanges);
       return _mapper.Map<IEnumerable<CustomerDto>>(customer);
    }

    public Customer GetOneCustomerById(int id, bool trackChanges)
    {
        var customer =  _manager.Customer.GetOneCustomerById(id, trackChanges);
        if (customer is null)
            throw new CustomerNotFoundException(id);
        return customer;
    }

    public Customer CreateOneCustomer(Customer customer)
    {
        
        
        if (customer is null)
        {
            string msg = "Customer is null";
            _logger.LogError(msg);
            throw new ArgumentNullException(nameof(customer));
        }
        string CreateMessage = $"Customer with id {customer.Id} is created";
        _logger.LogInfo(CreateMessage);
        _manager.Customer.CreateOneCustomer(customer);
        _manager.Save();
        return customer;
        
    }
    

    public void UpdateOneCustomer(int id, CustomerDto customerDto, bool trackChanges)
    {
        var entity = _manager.Customer.GetOneCustomerById(id, trackChanges);
        if (entity is null)
            throw new CustomerNotFoundException(id);

        entity = _mapper.Map<Customer>(customerDto);
        _manager.Customer.Update(entity);
        _manager.Save();
    }
    

    public void DeleteOneCustomer(int id, bool trackChanges)
    {
        var entity = _manager.Customer.GetOneCustomerById(id, trackChanges);
        if (entity is null)
            throw new CustomerNotFoundException(id);
            
        _manager.Customer.DeleteOneCustomer(entity);
        _manager.Save();

    }
}