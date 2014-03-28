// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace BugTracker.Model
{
    public interface IBugsRepository
    {
        IEnumerable<Bug> GetBugs();
    }
}