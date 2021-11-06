using AutoMapper;
using HorseRaceBackend.Dtos;
using HorseRaceBackend.Entities;

namespace HorseRaceBackend.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<HorseAddDto, Horse>();
            CreateMap<BettorAddDto, Bettor>();
            CreateMap<BettorUpdateDto, Bettor>().ReverseMap();
        }
    }
}
