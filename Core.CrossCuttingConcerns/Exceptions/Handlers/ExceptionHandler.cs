using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers;
public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception) =>
        exception switch
        {
            BusinessException businessException => HandleException(businessException),
            ValidationException validationException => HandleException(validationException),
            _ => HandleException(exception)
        };

    protected abstract Task HandleException(BusinessException exception);
    protected abstract Task HandleException(ValidationException exception);
    protected abstract Task HandleException(Exception exception);
}
