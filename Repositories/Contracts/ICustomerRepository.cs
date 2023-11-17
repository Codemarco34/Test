using Entities.Models;

namespace Repositories.Contracts;

public interface ICustomerRepository : IRepositoryBase<Customer>
{
    IQueryable<Customer> GetAllCustomers(bool trackChanges);
    Customer GetOneCustomerById(int id ,bool trackChanges);
    void CreateOneCustomer(Customer customer);
    void UpdateOneCustomer(Customer customer);
    void DeleteOneCustomer(Customer customer);


}