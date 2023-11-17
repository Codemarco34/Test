using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore;

public class CustomerRepository : RepositoryBase<Customer> , ICustomerRepository
{
    public CustomerRepository(RepositoryContext context) : base(context)
    {
    }

    public IQueryable<Customer> GetAllCustomers(bool trackChanges) => 
        FindAll(trackChanges).OrderBy(c=> c.Id);


    public Customer GetOneCustomerById(int id, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();
    

    public void CreateOneCustomer(Customer customer) => Create(customer);


    public void UpdateOneCustomer(Customer customer) => Update(customer);
    

    public void DeleteOneCustomer(Customer customer) => Delete(customer);

}