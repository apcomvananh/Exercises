using AutoMapper;
using TOEICEssentialWords.Web.Areas.Admin.Mappings;
using TOEICEssentialWords.Web.Mappings;

namespace TOEICEssentialWords.Web
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AdminDomainToViewModelMappingProfile>();
                x.AddProfile<DomainToViewModelMappingProfile>();
            });
        }
    }
}