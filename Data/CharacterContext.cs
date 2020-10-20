using Microsoft.EntityFrameworkCore;
using RpgGame.Models;

namespace RpgGame.Data
{
    public class CharacterContext : DbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> opt) : base(opt)
        {

        }

        public DbSet<Character> Characters { get; set; }
    }
}