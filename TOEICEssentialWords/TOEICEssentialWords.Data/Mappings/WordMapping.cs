using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Data.Mappings
{
    public class WordMapping : BaseEntityMapping<Word>
    {
        public WordMapping()
        {
            Property(w => w.Name);
            Property(w => w.WordType);
            Property(w => w.BrEPronoun);
            Property(w => w.BrESoundUrl);
            Property(w => w.NAmEPronoun);
            Property(w => w.NAmESoundUrl);
            Property(w => w.Slug);
            Property(w => w.LessonId);

            ToTable("Word");

            HasRequired(w => w.Lesson).WithMany(l => l.WordsToLearn).HasForeignKey(w => w.LessonId).WillCascadeOnDelete(false);
        }
    }
}