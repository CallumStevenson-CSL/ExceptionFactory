using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionFactory.WebApi;

public class CustomExceptionFilter : IExceptionFilter
{
    private readonly ILogger<CustomExceptionFilter> _logger;

    public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
    {
        _logger = logger;
    }
    
    public void OnException(ExceptionContext context)
    {
        string message = context.Exception.Message;
        
        _logger.LogError("[{time}] Runtime Exception with message: {exceptionMessage}", DateTime.Now, message);

        ActionResult result = new ObjectResult("An error occurred, please try again.")
        {
            StatusCode = 500
        };

        context.Result = result;

    }
}