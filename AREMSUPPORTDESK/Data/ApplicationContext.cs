using System.Runtime.InteropServices.JavaScript;
using Entities.DTOs;
using Entities.Models;

namespace AREMSUPPORTDESK.Data;

public static class ApplicationContext
{
    public static List<Customer> Customers { get; }
    public static List<Maintenance> Maintenances { get; }
    public static List<TicketDto> Tickets { get; }
    public static List<ResponseDto> Responses { get; }
    public static List<UserDto> Users { get; }
    static ApplicationContext()
    {
        Customers = new List<Customer>()
        {
            new Customer()
            {
                Id = 1,
                CustomerCode = "1",
                Title = "AREM",
                CustomerTaxNumber = 123,
                MainCurrentCode = 2014,
                Adress = "Kozyatağı",
                Active = true,
                Esolutions = "E-arşiv",
                Modul = "Temel Üretim-IK-Ileri Seviye Uretim",
                ProductGroup = "FLY",
                MaintenanceDate = DateTime.Now,
                Version = "V16"
            },
            new Customer()
            {
                Id = 2,
                CustomerCode = "2",
                Title="Sarboy",
                CustomerTaxNumber = 01041997,
                MainCurrentCode = 05061968,
                Active = false,
                Adress = "Kozyatağı",
                Esolutions = "E-Fatura",
                Modul = "Genel Muhasebe",
                ProductGroup = "JUMB",
                MaintenanceDate = DateTime.Now,
                Version = "V16"
            },
            new Customer()
            {
                Id = 3,
                CustomerCode = "3",
                Title = "Mopaş",
                CustomerTaxNumber = 14051997,
                MainCurrentCode = 11031984,
                Active = true,
                Esolutions = "E-Irsaliye",
                Modul = "Fatura",
                ProductGroup = "FLY",
                Adress = "Kozyatağı",
                MaintenanceDate = DateTime.Now,
                Version = "V16"
            },
            
        };
        Maintenances = new List<Maintenance>()
        {
            new Maintenance()
            {
                Id = 1,
                Customer = "Test",
                DealType = "Deneme",
                Explanation = "Açıklama",
                FinishDate = DateTime.Now,
                IsActive = true,
                ServicePeriod = "Sürekli",
                ServiceTime = 30,
                StartDate = DateTime.Today,
                TaxNumber = 20231231
            }

        };
        Tickets = new List<TicketDto>()
        {
            new TicketDto()
            {
                Id = 1,
                UserId = 1,
                Subject = "Arem Destek",
                CreationDate = DateTime.Now,
                Description = "Test",
                Responses = new List<ResponseDto>
                {
                    new ResponseDto()
                    {
                        Content = "Cevap 1",
                        CreationDate = DateTime.Now,
                        UserId = 2,
                        User = new UserDto()
                        {
                            UserName = "CevapVerenKullanici"
                        }
                    },
                    // Diğer cevaplar
                }
            },
            // Diğer ticket'lar
        };

        Users = new List<UserDto>()
        {
            new UserDto()
            {
                Id = 1,
                UserName = "Halis",
            },
            // Diğer kullanıcılar
        };
    }
}
