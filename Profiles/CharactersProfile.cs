using AutoMapper;
using RpgGame.Dtos;
using RpgGame.Models;

namespace RpgGame.Profiles
{
    public class CharactersProfile : Profile
    {
        public CharactersProfile()
        {
            CreateMap<Character, GetCharacterDto>().ReverseMap();
            CreateMap<Character, AddCharacterDto>().ReverseMap();
            CreateMap<Character, UpdateCharacterDto>().ReverseMap();
            CreateMap<UpdateCharacterDto, GetCharacterDto>().ReverseMap();
        }
    }
}