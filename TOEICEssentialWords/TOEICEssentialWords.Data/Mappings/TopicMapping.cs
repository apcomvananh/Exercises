using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Data.Mappings
{
    public class TopicMapping : BaseEntityMapping<Topic>
    {
        public TopicMapping()
        {
            Property(t => t.Name);
            Property(t => t.Index);

            ToTable("Topic");
        }
    }
}