using System.ComponentModel;
using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TRequest>
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        this.validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResult = await Task.WhenAll(validators.Select(x => x.ValidateAsync(context)));

        var failure = validationResult.Where(x => x.Errors.Any()).SelectMany(x => x.Errors).ToList();
        if (failure.Any())
        {
            throw new ValidationException(string.Join(", ", failure));
        }
        return await next();
    }
}
