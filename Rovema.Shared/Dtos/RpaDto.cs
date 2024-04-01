namespace Rovema.Shared.Dtos;

public record CreateRpaDto (Guid Id, string? Name, string? Type, int? TimeZone, int? TimeToFail, bool? Active);
