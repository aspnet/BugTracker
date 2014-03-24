using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BugTrackerAsOwinApp.Hubs
{
    [HubName("bugs")]
    public class BugHub : Hub
    {
    }
}