using Entities.LogModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NLog.Fluent;
using Services.Contracts;
using RouteData = Microsoft.AspNetCore.Routing.RouteData;

namespace Presentation.ActionFilters;

public class LogFilterAttribute : ActionFilterAttribute
{
    private readonly ILoggerService _logger;
    

    public LogFilterAttribute(ILoggerService logger)
    {
        _logger = logger;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInfo(Log("OnActionExecuting",context.RouteData));
    }

    private string Log(string modelName, RouteData routeData)
    {
        var logDetails = new LogDetails()
        {
            ModelName = modelName,
            Controller = routeData.Values["controller"],
            Action = routeData.Values["action"]

        };
        if (routeData.Values.Count >= 1)
            logDetails.Id = routeData.Values["Id"];
        return logDetails.ToString();

    }
}