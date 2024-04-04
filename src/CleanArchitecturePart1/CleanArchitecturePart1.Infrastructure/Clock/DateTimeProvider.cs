using ClearArchitecture.Application.Abstractions.Clock;

namespace ClearArchitecture.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime currentTime => DateTime.UtcNow;
}