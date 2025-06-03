using System;
using MediatR;

namespace BuildingBlocks.CQRS;

//Request handler
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
where TCommand : ICommand<TResponse>
where TResponse : notnull
{
}

//Request handler for void return type
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit>
where TCommand : ICommand
{
}
