using IES.Domain.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IdentityUserManager IdentityUserManager { get; }
        IdentityRoleManager IdentityRoleManager { get; }
        

        

        IUserRepository Users { get; }
        ICompanyRepository Companys { get; }
        IDealRepository Deals { get; }

        int Commit();
    }
}
