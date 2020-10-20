using RpgGame.Models;
using System.ComponentModel.DataAnnotations;
namespace RpgGame.Dtos
{
    public class AddCharacterDto
    {
        [Required]
        [MaxLength(250)]
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
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}