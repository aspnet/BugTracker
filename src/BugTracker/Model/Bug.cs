// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace BugTracker.Model
{
    public class Bug
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string state { get; set; }
    }
}