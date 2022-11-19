using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;
// using dotnet_rpg.Models;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        
        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get()
        {
            var characters = _characterService.GetAllCharacters();
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle([FromRoute] int id)
        {
            var character = _characterService.GetCharacterById(id);
            return Ok(character);
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter([FromBody] Character newCharacter)
        {
            var charactersWithNewCharacter = _characterService.AddCharacter(newCharacter);
            return Ok(charactersWithNewCharacter);
        }
    }
}