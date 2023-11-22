using IES.DataContext.DataContext;
using IES.Domain.Entities.Models;
using IES.Domain.Interfaces;
using IES.Domain.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Domain.Repositories
{
    public class CompanyRepository: Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(IESEducationContext context) : base(context)
        {
            //List<CompanyDTO> GetAll();
            //Task<List<CompanyDTO>> GetCompanies();
            //Task<CompanyDTO> GetCompaniesWithDeals(int companyId);
        }
        //public List<Company> GetCompaniesWithDeals()
        //{
        //    return _stockContext.Companys.Include(x => x).ToList();
        //}

        //public Organization GetCompanyWithDeal(int organizationId)
        //{
        //    return _GQMContext.Organizations.Include(x => x.Users).Where(w => w.Id == organizationId).FirstOrDefault();
        //}
    }
}