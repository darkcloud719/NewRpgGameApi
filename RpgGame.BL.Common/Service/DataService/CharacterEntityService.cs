using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RpgGame.BL.Common.Dto;
using RpgGame.Data;
using RpgGame.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.BL.Common.Service.DataService
{
    public class CharacterEntityService : ICharacterEntityService
    {
        private readonly MallDbContext _context;

        private readonly IMapper _mapper;

        public CharacterEntityService(IMapper mapper, MallDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CharacterReadDto>> Delete(int id)
        {
            var dtos = new List<CharacterReadDto>();

            try
            {
                Character character = _context.Character.First(c => c.Id == id);
                _context.Character.Remove(character);
                if (await SaveChanges())
                    dtos = _context.Character.Select(c => _mapper.Map<CharacterReadDto>(c)).ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return null;
            }

            return dtos;
        }

        public async Task<List<CharacterReadDto>> Insert(CharacterAddDto newCharacter)
        {
            var dtos = new List<CharacterReadDto>();

            try
            {
                Character character = _mapper.Map<Character>(newCharacter);
                _context.Character.Add(character);
                if (await SaveChanges())
                    dtos = _context.Character.Select(c => _mapper.Map<CharacterReadDto>(c)).ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return null;
            }

            return dtos;
        }

        public async Task<List<CharacterReadDto>> Query()
        {
            var dtos = new List<CharacterReadDto>();
            
            try
            {
                dtos = _context.Character.Select(c => _mapper.Map<CharacterReadDto>(c)).ToList();
            }
            catch(Exception ex)
            {
                return null;
            }

            return dtos;
        }

        public async Task<CharacterReadDto> Query(int id)
        {
            var dto = new CharacterReadDto();
            
            try
            {
                dto = _mapper.Map<CharacterReadDto>(_context.Character.AsNoTracking().First(c => c.Id == id));
            }
            catch(Exception ex)
            {
                return null;
            }

            return dto;
        }

        public async Task<bool> SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<CharacterReadDto> Update(CharacterUpdateDto updateCharacter)
        {
            var dto = new CharacterReadDto();

            try
            {
                Character character = _context.Character.First(c => c.Id == updateCharacter.IdForUpdate);

                character = _mapper.Map<CharacterUpdateDto, Character>(updateCharacter, character);

                _context.Update(character);

                if (await SaveChanges())
                    dto = _mapper.Map<CharacterReadDto>(character);
            }
            catch(Exception ex)
            {
                return null;
            }

            return dto;
        }
    }
}
