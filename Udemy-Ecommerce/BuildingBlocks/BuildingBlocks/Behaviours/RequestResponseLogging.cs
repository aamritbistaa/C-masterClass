using System;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Behaviours;

public class RequestResponseLogging<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : class
{
    private readonly ILogger<RequestResponseLogging<TRequest, TResponse>> _logger;
    public RequestResponseLogging(ILogger<RequestResponseLogging<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        var requestJson = JsonSerializer.Serialize(request);

        _logger.LogInformation("Request at {RequestTime}: Handling request {RequestJson}", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), requestJson);

        var response = await next();

        var responseJson = JsonSerializer.Serialize(response);

        _logger.LogInformation("Response at {ResponseTime}: Handling request {RequestJson}", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), responseJson);

        return response;
    }
}
