using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Data.Infrastructure.Base
{
    public interface ICreateAudited
    {
        DateTime CreateTime { get; set; }
        string CreateUser { get; set; }
    }
}
