using Microsoft.AspNetCore.SignalR;

using SignalRTestProject.Data;

using System.Threading.Tasks;

namespace SignalRTestProject.Hubs
{
    public class BannerHub : Hub
    {
        public async Task MessageChange(string message)
        {
            MessageRepository.BannerMessage = message;
            await Clients.Others.SendAsync("BannerMessageChanges", message);
        }
    }
}
