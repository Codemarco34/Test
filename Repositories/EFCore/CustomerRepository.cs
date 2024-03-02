using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore;

public class CustomerRepository : RepositoryBase<Customer> , ICustomerRepository
{
    public CustomerRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<PagedList<Customer>> GetAllCustomersAsync(CustomerParameters customerParameters,
        bool trackChanges)
    {
        var customer = await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();
        return PagedList<Customer>
            .ToPagedList(customer, customerParameters.PageNumber, customerParameters.PageSize);

    }
        


    public async Task<Customer> GetOneCustomerByIdAsync(int id, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    

    public void CreateOneCustomer(Customer customer) => Create(customer);


    public void UpdateOneCustomer(Customer customer) => Update(customer);
    

    public void DeleteOneCustomer(Customer customer) => Delete(customer);

}