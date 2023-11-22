using FastMapper;
using IES.Domain.Entities.Models;
using IES.Domain.Interfaces.UnitOfWork;
using IES.Services.DTO.DTO;
using IES.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace IES.Services.Services
{
    public class CompanyService : ICompanyService
    {
        public IUnitOfWork unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

       // public void UpdateCountOfStock(int id)
       // {

           // QuizAttempt quizAttempt = unitOfWork.QuizAttempts.GetAll().Where(x=> x.MarkId).Mark
            //quizAttempt.Mark;
           // Company company = unitOfWork.Companys.GetById(id);
           // company.CountOfStock = company.CountOfStock - company.StockPrice;

           // unitOfWork.Companys.Update(company);
           // unitOfWork.Commit();
            //var countofstockcomp = TypeAdapter.Adapt<CompanyDTO>(unitOfWork.Companys.GetById(id)).CountOfStock;
            //var countofstockdea = TypeAdapter.Adapt<CompanyDTO>(unitOfWork.Companys.GetById(id)).StockPrice;
            //var newcountofstock = countofstockcomp - countofstockdea;
            //var refsd = unitOfWork.Companys.Where(rtweds => rtweds.CountOfStock==newcountofstock);

            //unitOfWork.Companys.Update(TypeAdapter.Adapt<Company>(companyDTO));
            //unitOfWork.Commit();
      //  }


        public int GetCountOfStock(int id)
        {
            var countOfStock = TypeAdapter.Adapt < CompanyDTO > (unitOfWork.Companys.GetById(id));
            return countOfStock.CountOfStock;
        }
        //CompanyDTO countOfStock = TypeAdapter.Adapt<CompanyDTO>(unitOfWork.Companys.GetById(id));
        public void Create(CompanyCreateDTO companyDTO)
        {

            unitOfWork.Companys.Create(TypeAdapter.Adapt<Company>(companyDTO));
            unitOfWork.Commit();
        }
        public CompanyDTO GetById(int id)
        {
            return TypeAdapter.Adapt<CompanyDTO>(unitOfWork.Companys.GetById(id));    
        }
        
        public List<CompanyDTO> GetAllCompanies()
        {
            return TypeAdapter.Adapt<List<Company>, List<CompanyDTO>>(unitOfWork.Companys.GetAll());
        }
        public IEnumerable<CompanyDTO> GetAll()
        {
            return TypeAdapter.Adapt<IEnumerable<CompanyDTO>>(unitOfWork.Companys.GetAll());
        }

        public async Task<IEnumerable<CompanyDTO>> GetAllAsync()
        {
            var users = TypeAdapter.Adapt<IEnumerable<CompanyDTO>>(await unitOfWork.Companys.GetAllAsync());
            return users;
        }

        public bool Remove(int id)
        {
            Company entity = unitOfWork.Companys.GetById(id);
            unitOfWork.Companys.Remove(entity);
            return unitOfWork.Commit() > 0;
        }

        public bool Update(CompanyDTO companyDTO)
        {
            unitOfWork.Companys.Update(TypeAdapter.Adapt<CompanyDTO, Company>(companyDTO));
            return unitOfWork.Commit() > 0;
        }

        public void UpdateCompanyStockCount(int companyId, int stockCount)
        {
            Company company = unitOfWork.Companys.GetById(companyId);
            company.CountOfStock = stockCount;
            unitOfWork.Companys.Update(company);
            unitOfWork.Commit();
        }

        public void UpdateCompanyStockPrice(int companyId, int stockPrice)
        {
            Company company = unitOfWork.Companys.GetById(companyId);
            company.StockPrice = stockPrice;
            unitOfWork.Companys.Update(company);
            unitOfWork.Commit();
        }

        public void CompanyStockDischarge(int companyId, int dealid)
        {
            Company company = unitOfWork.Companys.GetById(companyId);
            Deal deal = unitOfWork.Deals.GetById(dealid);
            company.CountOfStock = (company.CountOfStock - deal.CountOfStockDeal);
            unitOfWork.Companys.Update(company);
            unitOfWork.Commit();
        }

        public int GetPriceByAmount(int id, int amount)
        {
            var Company = unitOfWork.Companys.GetById(id).StockPrice;
            return Company * amount;
        }

        public int CountCompanyPrice(int companyId)
        {
            var company = unitOfWork.Companys.GetById(companyId);

            var alldeal = unitOfWork.Deals.GetAll().Where(x => x.CompanyId == companyId);
            company.Deals = alldeal.ToList();

            var result = 0;
            foreach (var item in company.Deals)
            {
                result += item.CountOfStockDeal;
            }

            return result * company.StockPrice;
        }
    }
}

//public async Task<CompanyDTO> GetCompaniesWithDeals(int organizationId)
        //{
        //    Company company = unitOfWork.Companys.GetCompaniesWithDeals(organizationId);
        //    OrganizationDTO organizationDTO = TypeAdapter.Adapt<OrganizationDTO>(organization);
        //    foreach (var user in organizationDTO.Users)
        //    {
        //        var roles = await unitOfWork.IdentityUserManager.GetRolesAsync(await unitOfWork.IdentityUserManager.FindByIdAsync(user.Id));
        //        user.Roles = roles.ToList();
        //    }

        //    return organizationDTO;
        //}

        //public async Task<List<CompanyDTO>> GetCompanies()
        //{
        //    var companies = unitOfWork.Companys.GetCompanies();

        //    List<CompanyDTO> companyDTOs = TypeAdapter.Adapt<List<CompanyDTO>>(companies);
        //    return companyDTOs;
        //}