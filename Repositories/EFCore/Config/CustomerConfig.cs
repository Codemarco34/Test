using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData(
            new Customer
            {
                Id = 1,
                CustomerCode = "1",
                Title = "AREM",
                CustomerTaxNumber = 2014,
                Active = false,
                Adress = "Kozyatağı",
                Esolutions = "E-fatura",
                MainCurrentCode = 2014,
                MaintenanceDate = DateTime.Now,
                Modul = "FLY",
                ProductGroup = "AREM",
                Version = "v16"
            }
        );
    }

}
