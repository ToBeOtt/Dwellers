using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SharedKernel.ServiceResponse;

namespace Dwellers.Authentication.Domain
{
    public sealed class DbUser : IdentityUser
    {
        public string Alias { get; set; }

        public DbUser() { }

        public async Task<DwellerResponse<bool>> CreateUser(string email, string alias)
        {
            DwellerResponse<bool> DwellerResponse = new();

            var emailResponse = await SetEmail(email);
            if (!emailResponse.IsSuccess) return (emailResponse);

            var aliasResponse = await SetAlias(alias);
            if (!aliasResponse.IsSuccess) return (aliasResponse);

            return await DwellerResponse.SuccessResponse();
        }

        public async Task<DwellerResponse<bool>> SetEmail(string email)
        {
            DwellerResponse<bool> DwellerResponse = new();
            if (this.UserName != null && this.UserName != email)
                return await DwellerResponse.ErrorResponse("Email is not the same as username.");

            Email = email;
            UserName = email;

            return await DwellerResponse.SuccessResponse();
        }

        public async Task<DwellerResponse<bool>> SetAlias(string alias)
        {
            DwellerResponse<bool> DwellerResponse = new();
            if (alias.IsNullOrEmpty())
                return await DwellerResponse.ErrorResponse("Username is not the same as username.");

            Alias = alias;
            return await DwellerResponse.SuccessResponse();
        }
    }
}
