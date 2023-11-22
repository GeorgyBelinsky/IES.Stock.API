using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IES.Education.API.Models
{
    public class SignUpModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
