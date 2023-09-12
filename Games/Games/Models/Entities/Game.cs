using System.ComponentModel.DataAnnotations;

namespace Games.Models.Entities
{
    public record class Game
    {
        /// <summary>
        /// Игровые платформы
        /// </summary>
        public enum Platform
        {
            PlayStation4 = 0, PlayStation5, NintendoSwitch, XboxOne, PlayStation3,
            XboxSeries, Xbox360, Nintendo3DS, PlayStation2, Windows, MacOS, Linux
        }

        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public double RatingOnMetacritic { get; set; }
        public DateTime YearOfRelease { get; set; }
        public Platform Platforms { get; set; }
        public string? Developer { get; set; }
        public string? Genre { get; set; }
        public DateTime Update { get; set; }
    }
}
