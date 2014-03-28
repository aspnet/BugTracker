// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BugTrackerAsOwinApp.Hubs
{
    [HubName("bugs")]
    public class BugHub : Hub
    {
    }
}