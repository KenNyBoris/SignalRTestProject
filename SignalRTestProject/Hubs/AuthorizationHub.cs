using Microsoft.AspNetCore.SignalR;
using SignalRTestProject.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTestProject.Hubs
{
    public class AuthorizationHub: Hub
    {
        public async Task Login(string username)
        {
            var lastSession = SessionRepository.Sessions.OrderBy(s => s.Key).LastOrDefault();
            var newSessionId = lastSession.Key + 1;
            SessionRepository.Sessions.Add(newSessionId, username);
            await Clients.Others.SendAsync("UserLogined", newSessionId, username);
        }

        public async Task LogOut(int userId)
        {
            SessionRepository.Sessions.Remove(SessionRepository.Sessions.FirstOrDefault(s => s.Key == userId).Key);
            await Clients.Others.SendAsync("UserLogout", userId);
        }
    }
}
