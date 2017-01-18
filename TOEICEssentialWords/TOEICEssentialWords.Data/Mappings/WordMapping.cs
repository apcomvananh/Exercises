using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Data.Mappings
{
    public class WordMapping : BaseEntityMapping<Word>
    {
        public WordMapping()
        {
            Property(w => w.Name);
            Property(w => w.WordType);
            Property(w => w.Mean);
            Property(w => w.Examples);
            Property(w => w.LessonId);

            ToTable("Word");

            HasRequired(w => w.Lesson).WithMany(l => l.WordsToLearn).HasForeignKey(w => w.LessonId).WillCascadeOnDelete(false);
        }
    }
}