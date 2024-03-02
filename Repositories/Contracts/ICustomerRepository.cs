using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts;

public interface ICustomerRepository : IRepositoryBase<Customer>
{
    Task<PagedList<Customer>> GetAllCustomersAsync(CustomerParameters parameters,bool trackChanges);
    Task<Customer> GetOneCustomerByIdAsync (int id ,bool trackChanges);
    void CreateOneCustomer(Customer customer);
    void UpdateOneCustomer(Customer customer);
    void DeleteOneCustomer(Customer customer);


}