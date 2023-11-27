using Microsoft.AspNetCore.SignalR;

namespace UserNotification
{
    public sealed class NotificationsHub : Hub<INotification>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.RecieveNotification($"{Context.ConnectionId} has joined");
        }

        public async Task SendNotification(string message)
        {
            await Clients.All.RecieveNotification($"{Context.ConnectionId}: {message}");
        } 
    }
}
