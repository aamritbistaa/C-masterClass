using System;
using MediatR;

namespace BuildingBlocks.CQRS;

//Request handler (Command) for empty return type
public interface ICommand : IRequest<Unit>;

//Request handler (Command)
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
