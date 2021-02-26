using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTestProject.Data
{
    public static class SessionRepository
    {
        public static Dictionary<int,string> Sessions { set; get; }
        public static void Init()
        {
            Sessions = new Dictionary<int, string>();
        }
    }
}
