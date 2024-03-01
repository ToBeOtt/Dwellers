namespace Dwellers.Common.Application.Contracts.Results.Dwellings
{
    public record AttachDwellingToDwellerResult
    (
        string Name,
        Guid DwellingId
    );
}
