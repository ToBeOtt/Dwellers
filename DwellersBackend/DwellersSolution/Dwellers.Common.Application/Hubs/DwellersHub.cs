using Microsoft.AspNetCore.SignalR;

namespace Dwellers.Common.Application.Hubs
{
    public class DwellersHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }


        public async Task JoinConversationGroup(string conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId);
        }

        public async Task LeaveConversationGroup(string conversationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId);
        }

        public async Task NewMessage(string message, string conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId);

            await Clients.Group(conversationId).SendAsync("ReceiveMessage", message);
        }
    }
}
