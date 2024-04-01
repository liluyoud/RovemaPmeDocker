namespace Rovema.Shared.Contracts;

public record CreateRpaResquest (string? Name, string? Type, int TimeZone, int TimeToFail);
