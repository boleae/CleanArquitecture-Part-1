using CleanArchitecture.Application.Abstractions.Behaviors;

namespace CleanArchitecture.Application.Exceptions;

public sealed class ValidationException : Exception
{
    public ValidationException(IEnumerable<ValidationError> errors)
    {
        Errors = errors;
    }
    public IEnumerable<ValidationError> Errors {get;}
}
