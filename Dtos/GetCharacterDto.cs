using RpgGame.Models;

namespace RpgGame.Dtos
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Nick Chang";
        public int HitPoints { get; set; } = 10;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;

    }
}