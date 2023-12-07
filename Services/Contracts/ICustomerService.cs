using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts;

public interface ICustomerService
{
    IEnumerable<CustomerDto> GetAllCustomer(bool trackChanges);
    Customer GetOneCustomerById(int id , bool trackChanges);
    Customer CreateOneCustomer(Customer customer);
    void UpdateOneCustomer(int id, CustomerDto customerDto,bool trackChanges);
    void DeleteOneCustomer(int id, bool trackChanges);
    
}