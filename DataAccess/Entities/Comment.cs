using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Records.Bases;

namespace DataAccess.Entities
{
    public class Comment : RecordBase
    {
        [Required(ErrorMessage = "{0} is required!")]
        public string? UserComment { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
        public DateTime? AddedDateTime { get; set; }

    }
}
