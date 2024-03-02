using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config;

public class TicketConfig : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasData(
            new Ticket
            {
                Id = 1,
                UserId = 1,
                Subject = "Arem Destek",
                CreationDate = DateTime.Now,
                Description = "Test",
                IsActive = true,
                
                
            }
        );
    }

}
