namespace RovemaPme.Shared.Dtos;

public record RpaDto (Guid Id, string? Name, string? Type, int? TimeZone, int? TimeToFail, bool? Active);
