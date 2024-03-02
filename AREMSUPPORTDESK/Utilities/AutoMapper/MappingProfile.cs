using System.Runtime.CompilerServices;
using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace AREMSUPPORTDESK.Utilities.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CustomerDto, Customer>().ReverseMap();
        CreateMap<MaintenanceDto, Maintenance>().ReverseMap();
        CreateMap<TicketDto, Ticket>().ReverseMap();
        CreateMap<ResponseDto, Response>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<CustomerDtoForInsertion, Customer>();
        CreateMap<MaintenanceDtoForInsertion, Maintenance>();
        CreateMap<TicketDtoForInsertion, Ticket>();
        CreateMap<UserForRegistrationDto, User>();
     
    }
}