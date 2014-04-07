using System.Collections.Generic;

namespace BugTracker.Model
{
    public interface IBugsRepository
    {
        IEnumerable<Bug> GetBugs();
    }
}