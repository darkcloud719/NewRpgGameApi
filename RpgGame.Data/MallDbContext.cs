using Microsoft.EntityFrameworkCore;
using RpgGame.Data.Entities;
using RpgGame.Data.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Data
{
    public class MallDbContext : DbContext
    {
        public MallDbContext(DbContextOptions<MallDbContext>opt):base(opt)
        {

        }

        public DbSet<Character> Character { get; set; }
        //public DbSet<AuditedEntityBase> AuditedEntityBase { get; set; }
    }
}
