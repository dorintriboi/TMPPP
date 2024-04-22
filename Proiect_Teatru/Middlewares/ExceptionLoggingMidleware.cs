
using Domain.Core;
using Domain.Core.Exceptions;

namespace Proiect_Teatru.Middlewares;

public class ExceptionLoggingMiddleware(
    RequestDelegate next, 
    ILogger<ExceptionLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw;
        }
    }
    
    private void LogException(Exception ex)
    {
        switch (ex)
        {
            case ValidationException validationException:
                LogError(validationException, Constants.ValidationErrorLogMessage);
                break;
            case ContextualException contextualException:
                LogError(contextualException, Constants.ContextualErrorLogMessage);
                break;
            case DomainException domainException:
                LogError(domainException, Constants.DomainErrorLogMessage);
                break;
            default:
                LogError(ex, Constants.GenericErrorLogMessage);
                break;
        }
    }

    private void LogError(Exception exception, string errorMessage)
    {
        logger.LogError(exception, errorMessage);
    }
}
