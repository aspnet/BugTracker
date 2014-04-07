using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BugTracker.Hubs
{
    [HubName("bugs")]
    public class BugHub : Hub
    {
    }
}