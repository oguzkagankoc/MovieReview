using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Records.Bases;

namespace DataAccess.Entities
{
    public class Movie : RecordBase
    {
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(100, ErrorMessage = "{0} must have maximum {1} characters!")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        public Director? Director { get; set; }

        public int? DirectorId { get; set; }
        public List<Comment>? Comments { get; set; }

        public List<MovieGenre>? MovieGenres { get; set; }
    }
}
