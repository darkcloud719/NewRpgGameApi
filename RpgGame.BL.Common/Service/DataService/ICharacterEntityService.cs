using RpgGame.BL.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.BL.Common.Service.DataService
{
    public interface ICharacterEntityService
    {
        Task<List<CharacterReadDto>> Query();

        Task<CharacterReadDto> Query(int id);

        Task<List<CharacterReadDto>> Insert(CharacterAddDto newCharacter);

        Task<CharacterReadDto> Update(CharacterUpdateDto updateCharacter);

        Task<List<CharacterReadDto>> Delete(int id);

        Task<bool> SaveChanges();
    }
}
