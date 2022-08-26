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
    public partial class User : RecordBase
    {
        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(5, ErrorMessage = "{0} must have minimum {1} characters!")]
        [MaxLength(30, ErrorMessage = "{0} must have maximum {1} characters!")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(6, ErrorMessage = "{0} must have minimum {1} characters!")]
        [MaxLength(10, ErrorMessage = "{0} must have maximum {1} characters!")]
        public string? Password { get; set; }
        [MaxLength(30, ErrorMessage = "{0} must have maximum {1} characters!")]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [MaxLength(30, ErrorMessage = "{0} must have maximum {1} characters!")]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public List<Comment>? Comments { get; set; }
        
    }

    public partial class User
    {

        [NotMapped]
      
        public string? FirstNameDisplay { get; set; }

        [NotMapped]
      
        public string? LastNameDisplay { get; set; }
    }
}
