namespace Dwellers.Common.Application.Contracts.Results.Dwellings
{
    public record GetConnectedDwellingsResult (
        Dictionary<Guid, string?> ConnectedDwellings
        );

}
