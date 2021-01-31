using SV_TestTask.Common.Models;

namespace SV_TestTask.Dto
{
    public class Profile:AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<EntityBase, SearchResultEntity>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GetType().Name))
                .ForMember(dest => dest.Entity, opt => opt.MapFrom(src => src));
        }
    }
}