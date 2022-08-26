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
    public partial class Comment : RecordBase
    {
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("User Comment")]
        public string? UserComment { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
        [DisplayName("Added Date Time")]
        public DateTime? AddedDateTime { get; set; }

    }
    public partial class Comment
    {
        [NotMapped]
        public string? UserCommentDisplay { get; set; }

        [NotMapped]
        
        public string? AddedDateTimeDisplay { get; set; }

    }
}
