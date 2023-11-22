using IES.Domain.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.DataContext.DataContext
{
    public class IESEducationContext : IdentityDbContext<User>
   //public class Context : DbContext
    {
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public IESEducationContext(DbContextOptions<IESEducationContext> contextOptions) : base(contextOptions)
        {

        }
    }

}
