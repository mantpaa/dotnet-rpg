using AutoMapper;
using dotnet_rpg.Models;
using dotnet_rpg.Models.DTOs.Character;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
        }
    }
}