using AppCore.Records.Bases;

namespace DataAccess.Entities
{
    public class Genre : RecordBase
    {
        public string? GenreName { get; set; }
        public string? GenreDescription { get; set; }
        public List<MovieGenre>? MovieGenres { get; set; }
    }
}
