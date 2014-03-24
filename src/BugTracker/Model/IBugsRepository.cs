using System.Collections.Generic;

namespace BugTracker.Web.Model
{
    public interface IBugsRepository
    {
        IEnumerable<Bug> GetBugs();
    }
}