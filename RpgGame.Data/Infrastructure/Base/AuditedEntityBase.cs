using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Data.Infrastructure.Base
{
    public abstract class AuditedEntityBase
    {
        
        public virtual int Id { get; set; }

        [Column("CreateDate", TypeName = "datetime")]
        public DateTime CreationTime { get; set; }

        [Required]
        [MaxLength(100)]
        public string CreateUser { get; set; }

        [Column("ModifyDate", TypeName = "datetime")]
        public DateTime? LastModificationTime { get; set; }

        [MaxLength(100)]
        public string ModifyUser { get; set; }

        [Column("DeleteDate", TypeName = "datetime")]
        public DateTime? DeletionTime { get; set; }

        [MaxLength(100)]
        public string DeleteUser { get; set; }

        [Column("DeleteFlag")]
        public bool IsDeleted { get; set; }

    }

}
