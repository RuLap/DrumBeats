using AutoMapper;
using DrumBeatsUI.Models;
using DrumBeatsUI.Models.Respones;

namespace DrumBeatsUI.Mappings;

public class ExerciseProfile : Profile
{
    public ExerciseProfile()
    {
        CreateMap<ExerciseResponse, Exercise>()
            .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.title))
            .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.description));
    }
}