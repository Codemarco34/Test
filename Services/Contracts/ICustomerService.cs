using Entities.Models;

namespace Services.Contracts;

public interface ICustomerService
{
    IEnumerable<Customer> GetAllCustomer(bool trackChanges);
    Customer GetOneCustomerById(int id , bool trackChanges);
    Customer CreateOneCustomer(Customer customer);
    void UpdateOneCustomer(int id, Customer customer,bool trackChanges);
    void DeleteOneCustomer(int id, bool trackChanges);
}