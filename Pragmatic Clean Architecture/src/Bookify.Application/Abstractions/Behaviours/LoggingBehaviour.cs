using System;
using Bookify.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookify.Application.Abstractions.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;
        try
        {

            _logger.LogInformation("Executing command {Command}", name);
            var result = await next();
            _logger.LogInformation("Command {Command} executed successfully", name);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Command {Command} execution failed", name);
            throw;
        }

    }
}
