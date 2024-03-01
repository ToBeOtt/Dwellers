namespace Dwellers.Common.Application.Contracts.Results.Dwellings
{
    public record AttachDwellerToDwellingResult
    (
        string Name,
        string? Alias
    );
}
