using System.Text;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
namespace AREMSUPPORTDESK.Utilities.Fornatters;

public class CsvOutputFormatter : TextOutputFormatter
{
    public CsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);

    }

    protected override bool CanWriteType(Type? type)
    {
        if (typeof(CustomerDto).IsAssignableFrom(type)|| 
            typeof(IEnumerable<CustomerDto>).IsAssignableFrom(type) )
        {
            return base.CanWriteType(type);
        }
        return false;
    }

private static void FormatCsv(StringBuilder buffer, CustomerDto customer, MaintenanceDto maintenance)
{
    buffer.AppendLine($"" +
                      $"{customer.Id}," +
                      $"{customer.CustomerCode}," +
                      $"{customer.Active}," +
                      $"{customer.Adress}," +
                      $"{customer.CustomerTaxNumber}," +
                      $"{customer.Esolutions}," +
                      $"{customer.Modul}," +
                      $"{customer.Title}," +
                      $"{customer.Version}," + // Eksik virgül ekledim
                      $"{customer.MaintenanceDate}," + // Eksik virgül ekledim
                      $"{customer.ProductGroup}," +
                      $"{customer.MainCurrentCode}");

    buffer.AppendLine($"" +
                      $"{maintenance.Id}," +
                      $"{maintenance.Customer}," +
                      $"{maintenance.Explanation}," +
                      $"{maintenance.DealType}," +
                      $"{maintenance.FinishDate}," +
                      $"{maintenance.IsActive}," +
                      $"{maintenance.ServicePeriod}," +
                      $"{maintenance.ServiceTime}," +
                      $"{maintenance.StartDate}," +
                      $"{maintenance.TaxNumber}");
}

public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
{
    var response = context.HttpContext.Response;
    var buffer = new StringBuilder();

    if (context.Object is IEnumerable<CustomerDto>)
    {
        foreach (var customer in (IEnumerable<CustomerDto>)context.Object)
        {
            // MaintenanceDto nesnesini burada oluşturun veya temin edin
            var maintenance = new MaintenanceDto(); // Örnek bir MaintenanceDto oluşturuldu, gerçek nesneyi burada temin edin
            FormatCsv(buffer, customer, maintenance);
        }
    }
    else
    {
        // MaintenanceDto nesnesini burada oluşturun veya temin edin
        var maintenance = new MaintenanceDto(); // Örnek bir MaintenanceDto oluşturuldu, gerçek nesneyi burada temin edin
        FormatCsv(buffer, (CustomerDto)context.Object, maintenance);
    }

    await response.WriteAsync(buffer.ToString());
}

    
    
    
}