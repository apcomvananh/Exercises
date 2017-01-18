using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Data.Mappings
{
    public class LessonMapping : BaseEntityMapping<Lesson>
    {
        public LessonMapping()
        {
            Property(l => l.Name);
            Property(l => l.LessonNumber);
            Property(l => l.TopicId);

            ToTable("Lesson");

            HasRequired(l => l.Topic).WithMany(t => t.Lessons).HasForeignKey(l => l.TopicId).WillCascadeOnDelete(false);
        }
    }
}