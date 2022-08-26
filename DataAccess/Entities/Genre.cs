using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using AppCore.Records.Bases;

namespace DataAccess.Entities
{
    public partial class Genre : RecordBase
    {
        [DisplayName("Genre Name")]
        public string? GenreName { get; set; }
        [DisplayName("Genre Description")]
        public string? GenreDescription { get; set; }
        public List<MovieGenre>? MovieGenres { get; set; }
    }

    public partial class Genre
    {

        [NotMapped]
        public string? GenreNameDisplay { get; set; }

        [NotMapped]
        public string? GenreDescriptionDisplay { get; set; }
    }
}
