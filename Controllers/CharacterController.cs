using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Controllers.Services.CharacterService;
using dotnet_rpg.Models;
using dotnet_rpg.Models.DTOs.Character;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService _characterService;

        // Here we inject our character service into our character controller
        public CharacterController(ICharacterService characterService)
        {
           _characterService = characterService; 
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDTO newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
        {
            ServiceResponse<GetCharacterDTO> serviceResponse = await _characterService.UpdateCharacter(updatedCharacter);

            if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }
            return NotFound(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDTO>> serviceResponse = await _characterService.DeleteCharacter(id);
            if (serviceResponse.Success)
            {
                return Ok(serviceResponse);
            }
            return NotFound(serviceResponse);
        }
    }
}