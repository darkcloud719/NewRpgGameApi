using RpgGame.Data.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Data.Entities
{
    [Table("Character")]
    public class Character : AuditedEntityBase
    {
        [Key]
        [Column("SeqId")]
        public override int Id { get; set; }
        [Required]
        public string Name { get; set; } = "Nick Chang";
        [Required]
        public int HitPoints { get; set; } = 100;
        [Required]
        public int Strength { get; set; } = 10;
        [Required]
        public int Defense { get; set; } = 10;
        [Required]
        public int Intelligence { get; set; } = 10;
        [Required]
        public RpgClass RpgClass { get; set; } = RpgClass.Knight;

        //public bool? DeleteFlag { get; set; }
        //[Column(TypeName = "datetime")]
        //public DateTime? CreateDate { get; set; }
        //[StringLength(100)]
        //public string CreateUser { get; set; }
        //[Column(TypeName = "datetime")]
        //public DateTime? ModifyDate { get; set; }
        //[StringLength(100)]
        //public string ModifyUser { get; set; }
        //[Column(TypeName = "datetime")]
        //public DateTime? DeleteDate { get; set; }
        //[StringLength(100)]
        //public string DeleteUser { get; set; }
    }
}
