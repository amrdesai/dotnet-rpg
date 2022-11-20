using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character { Id = 1, Name = "Tillu" }
        };

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            Character characterToAdd = _mapper.Map<Character>(newCharacter);
            characterToAdd.Id = characters.Max(c => c.Id) + 1;
            characters.Add(characterToAdd);
            var response = new ServiceResponse<List<GetCharacterDto>>();
            response.Data = _mapper.Map<List<GetCharacterDto>>(characters);
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new ServiceResponse<List<GetCharacterDto>>() { Data = _mapper.Map<List<GetCharacterDto>>(characters) };
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            var mappedCharacter = _mapper.Map<GetCharacterDto>(character);
            var response = new ServiceResponse<GetCharacterDto>();
            response.Data = mappedCharacter;
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            
            try
            {
                Character characterToUpdate = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);    
                _mapper.Map(updatedCharacter, characterToUpdate);
                response.Data = _mapper.Map<GetCharacterDto>(characterToUpdate);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }
    }
}