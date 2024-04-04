using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Reviews;

public sealed record Rating {
    public int Value {get;init;}
    public static readonly Error Invalid = new("Rating.Invalid", "El rating es invalido");
    private Rating(int value) => Value = value;
    public static Result<Rating> Create(int value)
    {
        if(value < 1 || value > 5)
            return Result.Failure<Rating>(Invalid);
        return new Rating(value);

    }
};