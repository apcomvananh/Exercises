using AutoMapper;
using System.Linq;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Web.ViewModels;

namespace TOEICEssentialWords.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Topic, TopicViewModel>()
                .ForMember(vm => vm.HasChild, map => map.MapFrom(m => m.Lessons.Any()));

            Mapper.CreateMap<Lesson, LessonViewModel>()
               .ForMember(vm => vm.TopicName, map => map.MapFrom(m => m.Topic.Name));

            Mapper.CreateMap<Word, WordsToLearnViewModel>()
                .ForMember(vm => vm.WordClass, map => map.MapFrom(m => m.WordType.ToString()))
                .ForMember(vm => vm.Definition, map => map.MapFrom(m => string.Join(", ", m.Definitions.Take(2).Select(x => x.Name))))
                .ForMember(vm => vm.Examples, map => map.MapFrom(m => m.Definitions.Take(2).Select(x => x.Example)));

            Mapper.CreateMap<Word, WordViewModel>()
                .ForMember(vm => vm.WordType, map => map.MapFrom(m => m.WordType.ToString()))
                .ForMember(vm => vm.HasPronound, map => map.MapFrom(m => !(string.IsNullOrEmpty(m.BrEPronoun)
                                                                        && string.IsNullOrEmpty(m.BrESoundUrl)
                                                                        && string.IsNullOrEmpty(m.NAmEPronoun)
                                                                        && string.IsNullOrEmpty(m.NAmESoundUrl))));
        }
    }
}