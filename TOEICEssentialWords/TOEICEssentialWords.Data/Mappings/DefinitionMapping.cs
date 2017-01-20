using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Data.Mappings
{
    public class DefinitionMapping : BaseEntityMapping<Definition>
    {
        public DefinitionMapping()
        {
            Property(d => d.Name);
            Property(d => d.Example);

            ToTable("Definition");

            HasRequired(d => d.Word).WithMany(w => w.Definitions).HasForeignKey(d => d.WordId).WillCascadeOnDelete(false);
        }
    }
}