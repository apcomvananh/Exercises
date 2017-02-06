using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOEICEssentialWords.Model.Entities
{
    public interface SlugEntity : BaseEntity
    {
        string Name { get; set; }

        string Slug { get; set; }
    }
}