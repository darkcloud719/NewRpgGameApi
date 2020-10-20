using RpgGame.Data.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.BL.Common.Dto
{
    public class CharacterAddDto
    {
        public string NameForAdd { get; set; }

        public int HitPointsForAdd { get; set; }

        public int StrengthForAdd { get; set; }

        public int DefenseForAdd { get; set; }

        public int IntelligenceForAdd { get; set; }

        public RpgClass RpgClassForAdd { get; set; }
    }

    public class CharacterUpdateDto
    {
        public int IdForUpdate { get; set; }

        public string NameForUpdate { get; set; }

        public int HitPointsForUpdate { get; set; }

        public int StrengthForUpdate { get; set; }

        public int DefenseForUpdate { get; set; }

        public int IntelligenceForAdd { get; set; }

        public RpgClass RpgClassForUpdate { get; set; }
    }

    public class CharacterReadDto
    {
        public int IdForRead { get; set; }

        public string NameForRead { get; set; }

        public int HitPointsForRead { get; set; }

        public int StrengthForRead { get; set; }

        public int DefenseForRead { get; set; }

        public int IntelligenceForRead { get; set; }

        public RpgClass RpgClassForRead { get; set; }
    }

}
