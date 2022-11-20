using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character { Id = 1, Name = "Tillu" }
        };

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            characters.Add(newCharacter);
            var response = new ServiceResponse<List<GetCharacterDto>>();
            response.Data = characters;
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new ServiceResponse<List<GetCharacterDto>>() { Data = characters };
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            var response = new ServiceResponse<GetCharacterDto>();
            response.Data = character;
            return response;
        }
    }
}