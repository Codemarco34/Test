using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface ICustomerService
{
    Task<(IEnumerable<CustomerDto> customer, MetaData metaData)> GetAllCustomerAsync (CustomerParameters parameters,bool trackChanges);
    Task<CustomerDto> GetOneCustomerByIdAsync (int id , bool trackChanges);
    Task<CustomerDto> CreateOneCustomerAsync (CustomerDtoForInsertion customer);
    Task UpdateOneCustomerAsync (int id, CustomerDto customerDto,bool trackChanges);
    Task  DeleteOneCustomerAsync (int id, bool trackChanges);
    Task<(CustomerDto customerDto, Customer customer)> GetOneCustomerForPatchAsync (int id, bool trackChanges);
    Task SaveChangesForPatchAsync (CustomerDto customerDto, Customer customer);
}