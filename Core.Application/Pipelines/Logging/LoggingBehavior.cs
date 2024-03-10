﻿using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Serilog;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.Application.Pipelines.Logging;
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest, ILoggableRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LoggerServiceBase _loggerServiceBase;

    public LoggingBehavior(LoggerServiceBase loggerServiceBase, IHttpContextAccessor httpContextAccessor)
    {
        _loggerServiceBase = loggerServiceBase;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<LogParameter> logParameters = new()
        {
            new LogParameter{
                Type= request.GetType().Name,
                Value = request
            }
        };
        LogDetail logDetail = new()
        {

            MethodName = request.GetType().Name,
            Parameters = logParameters,
            FullName = request.GetType().FullName ?? string.Empty,
            User = _httpContextAccessor.HttpContext?.User.Identity?.Name?? "Anonymous"
        };

        _loggerServiceBase.Info(JsonSerializer.Serialize(logDetail));
        return await  next();
    }
}
