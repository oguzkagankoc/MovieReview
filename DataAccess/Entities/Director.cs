using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Records.Bases;

namespace DataAccess.Entities
{
    public class Director : RecordBase
    {
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(30, ErrorMessage = "{0} must have maximum {1} characters!")]
        public string? DirectorFirstName { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(30, ErrorMessage = "{0} must have maximum {1} characters!")]
        public string? DirectorLastName { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
