using AutoMapper;
using System.Linq;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Web.Areas.Admin.ViewModels;

namespace TOEICEssentialWords.Web.Areas.Admin.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<User, UserViewModel>()
                .ForMember(vm => vm.Roles, map => map.MapFrom(m => m.Roles.Select(r => r.Name).ToArray()));

            Mapper.CreateMap<Role, RoleViewModel>();

            Mapper.CreateMap<Topic, AdminTopicViewModel>();

            Mapper.CreateMap<Lesson, AdminLessonViewModel>()
                .ForMember(vm => vm.TopicName, map => map.MapFrom(m => m.Topic.Name))
                .ForMember(vm => vm.WordsInLesson, map => map.MapFrom(m => m.WordsToLearn.Count));

            Mapper.CreateMap<Word, AdminWordViewModel>()
                .ForMember(vm => vm.LessonName, map => map.MapFrom(m => m.Lesson.Name));
        }
    }
}