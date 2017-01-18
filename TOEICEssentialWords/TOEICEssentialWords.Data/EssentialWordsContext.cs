using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TOEICEssentialWords.Data.Mappings;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Data
{
    public class EssentialWordsContext : DbContext
    {
        public EssentialWordsContext()
            : base("Name=TOEICEssentialWords")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Role> Roles { get; set; }

        public IDbSet<Topic> Topics { get; set; }

        public IDbSet<Lesson> Lessons { get; set; }

        public IDbSet<Word> Words { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new TopicMapping());
            modelBuilder.Configurations.Add(new LessonMapping());
            modelBuilder.Configurations.Add(new WordMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new RoleMapping());
        }
    }
}