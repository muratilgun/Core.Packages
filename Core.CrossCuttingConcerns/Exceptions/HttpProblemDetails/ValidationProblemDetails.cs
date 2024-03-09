using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
public class ValidationProblemDetails : ProblemDetails
{
    public IEnumerable<ValidationExceptionModel> Errors { get; set; }

    public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Title = "Business Rule Violation";
        Detail = "One or more validation errors occerred.";
        Errors = errors;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
    }
}
