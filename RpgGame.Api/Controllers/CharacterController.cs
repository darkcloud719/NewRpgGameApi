using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RpgGame.BL.Common.Dto;
using RpgGame.BL.Service.ControllerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : Controller
    {
        private readonly ICharacterService _service;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("GetAll", Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var serviceResponse = await _service.GetAllCharacter();

            if (serviceResponse.Success == false)
                return NotFound(serviceResponse);
            return Ok(serviceResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var serviceResponse = await _service.GetCharacterById(id);

            if (serviceResponse.Success == false)
                return NotFound(serviceResponse);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(CharacterAddDto newCharacter)
        {
            var serviceResponse = await _service.AddCharacter(newCharacter);

            if (serviceResponse.Success == false)
                return NotFound(serviceResponse);
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var serviceResponse = await _service.DeleteCharacter(id);

            if (serviceResponse.Success == false)
                return NotFound(serviceResponse);
            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(CharacterUpdateDto updateCharacter)
        {
            var serviceResponse = await _service.UpdateCharacter(updateCharacter);

            if (serviceResponse.Success == false)
                return NotFound(serviceResponse);
            return Ok(serviceResponse);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialCharacterUpdate(int id, JsonPatchDocument<CharacterUpdateDto> patchDoc)
        {
            var serviceResponse = await _service.GetCharacterById(id);

            var characterModelFromRepo = serviceResponse.Data;

            var characterToPatch = _mapper.Map<CharacterUpdateDto>(characterModelFromRepo);

            patchDoc.ApplyTo(characterToPatch, ModelState);

            if(!TryValidateModel(characterToPatch))
            {
                return ValidationProblem(ModelState);
            }

            serviceResponse = await _service.UpdateCharacter(characterToPatch);

            if (serviceResponse.Success == false)
                return NotFound(serviceResponse);
            return Ok(serviceResponse);
            
        }

    }
}
