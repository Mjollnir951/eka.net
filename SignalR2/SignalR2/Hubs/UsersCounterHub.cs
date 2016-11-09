using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR2.Hubs
{
    [HubName("counter")]
    public class UsersCounterHub : Hub<ICounterClientHandler>
    {
        private static int counter = 0;

        public override Task OnConnected()
        {
            counter ++;
            Clients.All.UpdateCount(counter);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            counter --;
            Clients.All.UpdateCount(counter);
            return base.OnDisconnected(stopCalled);
        }
    }

    public interface ICounterClientHandler
    {
        void UpdateCount(int counter);
    }
}