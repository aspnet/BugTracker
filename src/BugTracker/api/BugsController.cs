﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using BugTracker.Model;
using BugTrackerAsOwinApp.Hubs;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugTrackerAsOwinApp.api
{
    public class BugsController : Controller
    {
        IBugsRepository _bugsRepository = new BugsRepository();
        private IHubContext _hub;

        public BugsController(IConnectionManager connectionManager)
        {
            _hub = connectionManager.GetHubContext<BugHub>();
        }

        public IEnumerable<Bug> Get()
        {
            return _bugsRepository.GetBugs();
        }

        //Once we have model binding we can uncomment this
        // Web API expects primitives coming from the request body to have no key value (e.g. '') - they should be encoded, then as '=value'

        //TODO: Once we have attribute based routing we can uncomment this. Not in alpha scope.
        //Bug: [FromBody] attribute does not work right now. Need to verify this once available.
        //[Route("api/bugs/backlog")]
        //public Bug PostToBacklog([FromBody] int id)
        public Bug BackLog(int id)
        {
            var bug = _bugsRepository.GetBugs().First(b => b.id == id);
            bug.state = "backlog";

            _hub.Clients.All.moved(bug);

            return bug;
        }

        //TODO: Once we have attribute based routing we can uncomment this. Not in alpha scope. 
        //Bug: [FromBody] attribute does not work right now. Need to verify this once available. 
        //[Route("api/bugs/working")]
        //public Bug PostToWorking([FromBody] int id)
        public Bug Working(int id)
        {
            var bug = _bugsRepository.GetBugs().First(b => b.id == id);
            bug.state = "working";

            _hub.Clients.All.moved(bug);

            return bug;
        }

        //TODO: Once we have attribute based routing we can uncomment this. Not in alpha scope. 
        //Bug: [FromBody] attribute does not work right now. Need to verify this once available. 
        //[Route("api/bugs/done")]
        //public Bug PostToDone([FromBody] int id)
        public Bug Done(int id)
        {
            var bug = _bugsRepository.GetBugs().First(b => b.id == id);
            bug.state = "done";

            _hub.Clients.All.moved(bug);

            return bug;
        }
    }
}