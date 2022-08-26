using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Records.Bases;

namespace DataAccess.Entities
{
    public partial class Director : RecordBase
    {
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(30, ErrorMessage = "{0} must have maximum {1} characters!")]
        [DisplayName("Director First Name")]
        public string? DirectorFirstName { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(30, ErrorMessage = "{0} must have maximum {1} characters!")]
        [DisplayName("Director Last Name")]
        public string? DirectorLastName { get; set; }
        public List<Movie>? Movies { get; set; }
    }

    public partial class Director
    {

        [NotMapped]
       
        public string? DirectorFirstNameDisplay { get; set; }

        [NotMapped]
       
        public string? DirectorLastNameDisplay { get; set; }
    }
}
