using RpgGame.BL.Common.Dto;
using RpgGame.BL.Common.Service.DataService;
using RpgGame.Data.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.BL.Service.ControllerService
{
    public class CharacterService : ICharacterService
    {
        private ICharacterEntityService _dataService;

        public CharacterService(ICharacterEntityService dataService)
        {
            _dataService = dataService;
        }

        public async Task<ServiceResponse<List<CharacterReadDto>>> AddCharacter(CharacterAddDto newCharacter)
        {
            ServiceResponse<List<CharacterReadDto>> serviceResponse = new ServiceResponse<List<CharacterReadDto>>();

            try
            {
                serviceResponse.Data = await _dataService.Insert(newCharacter);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterReadDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<CharacterReadDto>> serviceResponse = new ServiceResponse<List<CharacterReadDto>>();

            try
            {
                serviceResponse.Data = await _dataService.Delete(id); 
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterReadDto>>> GetAllCharacter()
        {
            ServiceResponse<List<CharacterReadDto>> serviceResponse = new ServiceResponse<List<CharacterReadDto>>();

            try
            {
                serviceResponse.Data = await _dataService.Query();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterReadDto>> GetCharacterById(int id)
        {
            ServiceResponse<CharacterReadDto> serviceResponse = new ServiceResponse<CharacterReadDto>();

            try
            {
                serviceResponse.Data = await _dataService.Query(id);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterReadDto>> UpdateCharacter(CharacterUpdateDto updateCharacter)
        {
            ServiceResponse<CharacterReadDto> serviceResponse = new ServiceResponse<CharacterReadDto>();

            try
            {
                serviceResponse.Data = await _dataService.Update(updateCharacter);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
