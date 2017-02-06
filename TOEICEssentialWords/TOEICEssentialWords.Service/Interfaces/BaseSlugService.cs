using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Service.Interfaces
{
    public interface BaseSlugService<T> : BaseService<T> where T : BaseEntity
    {
        T GetBySlug(string slug);

        IList<T> FindBySlug(string slug);
    }
}