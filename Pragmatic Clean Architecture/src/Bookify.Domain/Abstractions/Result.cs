using System;
using System.Diagnostics.CodeAnalysis;

namespace Bookify.Domain.Abstractions;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException("A successful result cannot have an error.");
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException("A failure result must have a valid error.");
        }
        IsSuccess = isSuccess;
        Error = error;
    }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error)
    {
        if (error == null || error == Error.None)
        {
            throw new ArgumentNullException(nameof(error), "Error cannot be null or 'None' for a failure result.");
        }
        return new(false, error);
    }

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result<TValue> Failure<TValue>(Error error)
    {
        if (error == null || error == Error.None)
        {
            throw new ArgumentNullException(nameof(error), "Error cannot be null or 'None' for a failure result.");
        }
        return new(default, false, error);
    }

    public static Result<TValue> Create<TValue>(TValue? value)
        => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}
public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }
    [NotNull]
    public TValue Value
    {
        get
        {
            if (!IsSuccess)
            {
                throw new InvalidOperationException("The value of a failure result cannot be accessed.");
            }
            return _value!;
        }
    }

    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}
