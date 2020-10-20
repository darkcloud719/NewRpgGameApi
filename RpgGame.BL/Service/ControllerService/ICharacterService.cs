using RpgGame.BL.Common.Dto;
using RpgGame.Data.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.BL.Service.ControllerService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterReadDto>>> GetAllCharacter();

        Task<ServiceResponse<CharacterReadDto>> GetCharacterById(int id);

        Task<ServiceResponse<List<CharacterReadDto>>> AddCharacter(CharacterAddDto newCharacter);

        Task<ServiceResponse<CharacterReadDto>> UpdateCharacter(CharacterUpdateDto updateCharacter);

        Task<ServiceResponse<List<CharacterReadDto>>> DeleteCharacter(int id);
    }
}
