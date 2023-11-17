using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class CustomerManager : ICustomerService
{
    private readonly IRepositoryManager _manager;

    public CustomerManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public IEnumerable<Customer> GetAllCustomer(bool trackChanges)
    {
        return _manager.Customer.GetAllCustomers(trackChanges);
    }

    public Customer GetOneCustomerById(int id, bool trackChanges)
    {
        return _manager.Customer.GetOneCustomerById(id, trackChanges);
    }

    public Customer CreateOneCustomer(Customer customer)
    {
        if (customer is null)
            throw new ArgumentNullException(nameof(customer));
        _manager.Customer.CreateOneCustomer(customer);
        _manager.Save();
        return customer;
    }

    public void UpdateOneCustomer(int id, Customer customer, bool trackChanges)
    {
        var entity = _manager.Customer.GetOneCustomerById(id, trackChanges);
        if (entity is null)
            throw new Exception($"Maintenance with id {id} could not found");
        if (customer is null)
            throw new ArgumentNullException(nameof(customer));

        entity.Active = customer.Active;
        entity.CustomerCode = customer.CustomerCode;
        entity.Esolutions = customer.Esolutions;
        entity.Modul = customer.Modul;
        entity.Title = customer.Title;
        entity.Version = customer.Version;
        entity.MaintenanceDate = customer.MaintenanceDate;
        entity.ProductGroup = customer.ProductGroup;
        entity.MainCurrentCode = customer.MainCurrentCode;
        entity.Adress = customer.Adress;
        entity.CustomerTaxNumber = customer.CustomerTaxNumber;
        _manager.Customer.Update(entity);
        _manager.Save();
    }
    

    public void DeleteOneCustomer(int id, bool trackChanges)
    {
        var entity = _manager.Customer.GetOneCustomerById(id, trackChanges);
        if (entity is null)
            throw new Exception($"Customer with id {id} could not found");
        _manager.Customer.DeleteOneCustomer(entity);
        _manager.Save();

    }
}