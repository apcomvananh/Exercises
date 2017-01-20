using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOEICEssentialWords.Model.Entities
{
    public class Definition : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Example { get; set; }

        public int WordId { get; set; }

        public virtual Word Word { get; set; }
    }
}