using IES.DataContext.DataContext;
using IES.Domain.Interfaces;
using IES.Domain.Interfaces.Interfaces;
using IES.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Domain.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IESEducationContext context, 
            IdentityUserManager IdentityUserManager, 
            IdentityRoleManager IdentityRoleManager,
            IUserRepository Users,
            ICompanyRepository Companys,
            IDealRepository Deals)
        {
            this.Companys = Companys;
            this.IdentityUserManager = IdentityUserManager;
            _context = context;
            this.IdentityRoleManager = IdentityRoleManager;
            _context = context;
            this.Users = Users;
            this.Deals = Deals;
        }

        private readonly IESEducationContext _context;
        public IdentityUserManager IdentityUserManager { get; }

        public IdentityRoleManager IdentityRoleManager { get; }


        public IRoleRepository Roles { get; }

        public IUserRepository Users { get; }
        public ICompanyRepository Companys { get; }
        public IDealRepository Deals { get; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
