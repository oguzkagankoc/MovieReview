using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.DataAccess.Results.Bases
{
    public abstract class Result
    {
        public bool IsSuccessful { get;}
        public string? Message { get; set; }
        protected Result(bool isSuccessful, string? message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
