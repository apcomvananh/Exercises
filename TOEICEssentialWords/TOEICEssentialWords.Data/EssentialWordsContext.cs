using System.Data.Entity;
using TOEICEssentialWords.Models.Entities;

namespace TOEICEssentialWords.Data
{
    public class EssentialWordsContext : DbContext
    {
        public EssentialWordsContext()
            : base("")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Role> Roles { get; set; }

        public IDbSet<Topic> Topics { get; set; }

        public IDbSet<Lesson> Lessons { get; set; }

        public IDbSet<Word> Words { get; set; }
    }
}