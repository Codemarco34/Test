using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config;

public class MaintenanceConfig : IEntityTypeConfiguration<Maintenance>
{
    public void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        builder.HasData(
            new Maintenance()
            {
                Id = 1,
                Customer = "Test",
                DealType = "Test",
                StartDate = DateTime.Now,
                FinishDate = DateTime.Today,
                ServicePeriod = "AREMTEST",
                ServiceTime = 50,
                TaxNumber =3456423,
                Explanation = "AREM TEST VERİON",
                IsActive = false
            }
        );
    }

  
}