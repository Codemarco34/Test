using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace AREMSUPPORTDESK.Utilities.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CustomerDto, Customer>();
        CreateMap<MaintenanceDto, Maintenance>();
        CreateMap<Customer, CustomerDto>();
    }
}