namespace Dwellers.Common.Application.Contracts.Commands.Dwellers
{
    public record AddDwellerCommand(
       string DwellerId,
       string Alias,
       string Email);
}
