using System.Collections.Generic;
using System.Linq;

namespace BugTracker.Model
{
    public class BugsRepository : IBugsRepository
    {
        private static readonly List<Bug> _repo;

        static BugsRepository()
        {
            _repo = new List<Bug>();

            //add some default values
            _repo.Add(new Bug { id = 1, title = "bug #1", description = "first bug", state = "backlog"});
            _repo.Add(new Bug { id = 2, title = "bug #2", description = "second bug", state = "working" });
            _repo.Add(new Bug { id = 3, title = "bug #3", description = "third bug", state = "done" });
            _repo.Add(new Bug { id = 4, title = "bug #4", description = "fourth bug", state = "backlog" });
            _repo.Add(new Bug { id = 5, title = "bug #5", description = "fifth bug", state = "working" });
            _repo.Add(new Bug { id = 6, title = "bug #6", description = "sixth bug", state = "done" });
        }

        public IEnumerable<Bug> GetBugs()
        {
            return _repo;
        }

        public Bug AddBug(Bug bug)
        {
            _repo.Add(new Bug { id = bug.id, title = bug.title, description = bug.description, state = bug.state });
            return bug;
        }

        public Bug UpdateBug(int id, string state)
        {
            Bug myBug = _repo.First(b => b.id == id);
            _repo.Remove(myBug);

            myBug.state = state;
            _repo.Add(myBug);

            return myBug;
        }

        public Bug DeleteBug(int id)
        {
            Bug myBug = _repo.First(b => b.id == id);
            _repo.Remove(myBug);

            return myBug;
        }
    }
}