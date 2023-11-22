using IES.DataContext.DataContext;
using IES.Domain.Entities.Models;
using IES.Domain.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Domain.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IESEducationContext context) : base(context)
        {

        }
    }
}
