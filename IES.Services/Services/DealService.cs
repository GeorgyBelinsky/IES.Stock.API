using FastMapper;
using IES.Domain.Entities.Models;
using IES.Domain.Interfaces.UnitOfWork;
using IES.Services.DTO.DTO;
using IES.Services.Interfaces.Interfaces;
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
    public class DealService : IDealService
    {
        public IUnitOfWork unitOfWork;
        public DealService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(DealCreateDTO dealDTO)
        {

            var price = unitOfWork.Companys.GetById((int)dealDTO.CompanyId).StockPrice;
            var count = dealDTO.CountOfStockDeal;

            if (dealDTO.ResultPrice == 0)
            {
                dealDTO.ResultPrice =  count * price;
            }

            unitOfWork.Deals.Create(TypeAdapter.Adapt<Deal>(dealDTO));
            unitOfWork.Commit();
        }

        public int GetPrice(int id)
        {
            var Deal = unitOfWork.Deals.GetById(id);
            return Deal.CountOfStockDeal * Deal.Company.StockPrice;
        }

        public IEnumerable<DealDTO> GetAll()
        {
            return TypeAdapter.Adapt<IEnumerable<DealDTO>>(unitOfWork.Deals.GetAll());
        }

        //public IEnumerable<DealDTO> GetDealsById(int Id)
        //{
        //    List<Deal> deals = unitOfWork.Deals.
        //    return Map(statistics);

        //    var deals = TypeAdapter.Adapt<IEnumerable<DealDTO>>(await unitOfWork.Deals.Get());
        //    return deals;
        //}

        public async Task<IEnumerable<DealDTO>> GetAllAsync()
        {
            var deals = TypeAdapter.Adapt<IEnumerable<DealDTO>>(await unitOfWork.Deals.GetAllAsync());
            return deals;
        }

        public List<Deal> GetByUserId(string Id)
        {
            var alldeal = unitOfWork.Deals.GetAll().Where(x=>x.UserId==Id);
            return alldeal.ToList();
        }

        public void AddDealToUserList(int dealId, string userId)
        {
            var alldeal = GetByUserId(userId);
            alldeal.Add(unitOfWork.Deals.GetById(dealId));
        }

        public void UpdateUserDealsList(int dealId)
        {
            DealDTO dealDTO = TypeAdapter.Adapt <DealDTO> (unitOfWork.Deals.GetById(dealId));
            List<Deal> main = GetByUserId(dealDTO.UserId);
            dealDTO.User.Deals = main;

            unitOfWork.Users.Update(dealDTO.User);
            unitOfWork.Commit();
        }

        public bool Update(DealDTO dealDTO)
        {
            unitOfWork.Deals.Update(TypeAdapter.Adapt<DealDTO, Deal>(dealDTO));
            return unitOfWork.Commit() > 0;
        }

        public List<Deal> GetByCompanyId(int Id)
        {
            var alldeal = unitOfWork.Deals.GetAll().Where(x => x.CompanyId == Id);
            return alldeal.ToList();
        }

        public async Task<bool> ConfirmDeal(int dealId)
        {
            DealDTO dealDTO = TypeAdapter.Adapt<DealDTO>(unitOfWork.Deals.GetById(dealId));
            UserDTO user = TypeAdapter.Adapt<UserDTO>(await unitOfWork.IdentityUserManager.FindByIdAsync(dealDTO.UserId));
            CompanyDTO company = TypeAdapter.Adapt<CompanyDTO>(unitOfWork.Companys.GetById((int)dealDTO.CompanyId));

            if ((dealDTO.ResultPrice - user.Resources) >= 0)
            {
                company.CountOfStock -= dealDTO.CountOfStockDeal;
                company.Resources += dealDTO.ResultPrice;

                dealDTO.IsSuccsesful = true;  

                user.Resources = company.CountOfStock -= dealDTO.ResultPrice;

                unitOfWork.Companys.Update(TypeAdapter.Adapt<Company>(company));
                unitOfWork.Deals.Update(TypeAdapter.Adapt<Deal>(dealDTO));
                await unitOfWork.IdentityUserManager.UpdateAsync(TypeAdapter.Adapt<User>(user));
                return true;
            }
            else
            return false;
        }
    }
}