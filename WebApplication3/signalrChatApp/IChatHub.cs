using System.Threading.Tasks;

namespace WebApplication3.signalrChatApp
{
    public interface IChatHub
    {
        public Task ReceiveMessage(string user, string message);
        public Task PlayerJoined(string user);
    }
}
