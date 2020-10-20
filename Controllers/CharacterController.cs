using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RpgGame.Data;
using RpgGame.Dtos;
using RpgGame.Models;

namespace RpgGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepo _repository;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAll", Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _repository.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> response = await _repository.AddCharacter(newCharacter);

            return CreatedAtRoute(nameof(GetAll), new { Id = response.Data[0].Id }, response.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            ServiceResponse<GetCharacterDto> response = await _repository.UpdateCharacter(updatedCharacter);

            if (response.Success == false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = await _repository.DeleteCharacter(id);
            if (response.Success == false)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialCharacterUpdate(int id, JsonPatchDocument<UpdateCharacterDto> patchDoc)
        {
            ServiceResponse<GetCharacterDto> response = await _repository.GetCharacterById(id);

            if (response.Success == false)
            {
                return NotFound();
            }

            var characterModelFromRepo = response.Data;

            var characterToPatch = _mapper.Map<UpdateCharacterDto>(characterModelFromRepo);

            patchDoc.ApplyTo(characterToPatch, ModelState);

            if (!TryValidateModel(characterToPatch))
            {
                return ValidationProblem(ModelState);
            }

            return Ok(await _repository.UpdateCharacter(characterToPatch));
        }
    }
}