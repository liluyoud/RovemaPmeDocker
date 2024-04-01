namespace Rovema.Shared.Contracts;

public record UpdateRpaRequest (Guid Id, string? Name, string? Type, int TimeZone, int TimeToFail, bool Active);
