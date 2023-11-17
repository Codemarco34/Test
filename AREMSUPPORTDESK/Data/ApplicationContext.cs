using System.Runtime.InteropServices.JavaScript;
using Entities.Models;

namespace AREMSUPPORTDESK.Data;

public static class ApplicationContext
{
    public static List<Customer> Customers { get; }
    public static List<Maintenance> Maintenances { get; }
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

    }
    
    
}