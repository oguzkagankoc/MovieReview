using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Records.Bases;

namespace DataAccess.Entities
{
    public class Role : RecordBase
    {
        [Required(ErrorMessage = "{0} is required!")]
        [MaxLength(30, ErrorMessage = "{0} must have maximum {1} characters!")]
        public string? RoleName { get; set; }

        public List<User>? Users { get; set; }
    }
}
