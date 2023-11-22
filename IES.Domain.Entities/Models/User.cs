using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Domain.Entities.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public Dictionary<int, int> Stocks { get; set; }
        public List<Deal> Deals { get; set; }

        //public int? UserGroupId { get; set; }
        //public UserGroup UserGroup { get; set; }
        //public List<Deal> AllDeal { get; set; }
    }
}

//public int UserGroupId { get; set; }
//public string UserGroupName { get; set; }
//public List<User> Users { get; set; }
