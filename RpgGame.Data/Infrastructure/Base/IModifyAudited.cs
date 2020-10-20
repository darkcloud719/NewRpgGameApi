using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Data.Infrastructure.Base
{
    public interface IModifyAudited
    {
        DateTime? LastModificationTime { get; set; }
        string ModifyUser { get; set; }
    }
}
