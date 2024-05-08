using Dwellers.Common.Application.Contracts.Queries.Chats;
using Dwellers.Common.Application.Contracts.Results.Chats;
using Dwellers.Common.Application.Interfaces.Chats;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;

namespace Dwellers.Common.Application.Queries.Chats.GetAllDwellingConversations
{
    public class GetAllDwellingConversationsQueryHandler(IChatQueryRepository chatQuery)
        : IQueryHandler<GetAllDwellingConversationsQuery, GetAllDwellingConversationsResult>
    {
        private readonly IChatQueryRepository _chatQuery = chatQuery;

        public async Task<DwellerResponse<GetAllDwellingConversationsResult>> Handle
            (GetAllDwellingConversationsQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetAllDwellingConversationsResult> response = new();

            var conversations = await _chatQuery.GetAllDwellingConversations(query.DwellingId);

            return await response.SuccessResponse(new(
                Conversations: conversations));
        }
    }
}
