using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using WebApplication3.signalrChatApp;

namespace WebApplication2.signalrChatApp
{
    public class ChatHub : Hub<IChatHub>
    {

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.ReceiveMessage(user, message);
        }

        public async Task PlayerJoined(string user)
        {
            await Clients.All.PlayerJoined(user);
        }

    }
}
