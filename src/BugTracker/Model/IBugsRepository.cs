using System.Collections.Generic;

namespace BugTracker.Model
{
    public interface IBugsRepository
    {
        IEnumerable<Bug> GetBugs();
        Bug AddBug(Bug b);
        Bug UpdateBug(int id, string state);
        Bug DeleteBug(int id);
    }
}