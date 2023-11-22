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
    public class DealRepository : Repository<Deal>, IDealRepository
    {
        public DealRepository(IESEducationContext context) : base(context)
        {

        }
        //public List<Deal> GetDealsByUserId(int DealId)
        //{
        //    return _stockContext.Deals.Include(a => a.CompanyId).Include(b => b.Id).Where(x => x.DealId == DealId).ToList();
        //}
    }
}