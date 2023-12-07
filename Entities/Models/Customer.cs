using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models;

public class Customer
{
    public int Id { get; set; }
    public string CustomerCode { get; set; }
    public string  Title { get; set; }
    public int CustomerTaxNumber { get; set; }
    public int MainCurrentCode { get; set; }
    public string Adress { get; set; }
    public string ProductGroup { get; set; }
    public string Version { get; set; }
    public string Modul { get; set; }
    public string Esolutions { get; set; }
    public DateTime MaintenanceDate { get; set; }
    public bool Active { get; set; }
    
    
    
    
    
}