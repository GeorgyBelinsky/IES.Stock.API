using FastMapper;
using IES.Domain.Entities.Models;
using IES.Education.API.Models;
using IES.Services.DTO.DTO;
using IES.Services.Interfaces.Interfaces;
using IES.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IES.Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealController : ControllerBase
    {
        public IDealService dealService;

        public DealController(IDealService dealService)
        {
            this.dealService = dealService;
        }

        [Route("Create")]
        [HttpPost]
        public void Create(DealCreateViewModel dealViewModel)
        {
            dealService.Create(TypeAdapter.Adapt<DealCreateDTO>(dealViewModel));
        }

        [Route("GetPrice")]
        [HttpGet]
        public int GetPriceByAmount(int id)
        {
            //return TypeAdapter.Adapt<DealViewModel>(await dealService.GetPriceByAmount(id,amount));
            return dealService.GetPrice(id);
        }

        [Route("All")]
        [HttpGet]
        public async Task<IEnumerable<DealViewModel>> GetAllAsync()
        {
            return TypeAdapter.Adapt<IEnumerable<DealViewModel>>(await dealService.GetAllAsync());
        }

        [Route("GetByUserId")]
        [HttpGet]
        public List<Deal> GetByUserId(string Id)
        {
            return TypeAdapter.Adapt<List<Deal>>(dealService.GetByUserId(Id));
        }

        [Route("UpdateUserDealsList")]
        [HttpPut]
        public void UpdateUserDealsList(int dealId)
        {
            dealService.UpdateUserDealsList(dealId);
        }

        [Route("ConfirmDeal")]
        [HttpPost]
        public async Task<bool> ConfirmDeal(int dealId)
        {
            return await dealService.ConfirmDeal(dealId);
        }

        [Route("GetByCompanyId")]
        [HttpGet]
        public List<Deal> GetByCompanyId(int Id)
        {
            return TypeAdapter.Adapt<List<Deal>>(dealService.GetByCompanyId(Id));
        }

        //[HttpPut]
        //[Route("UpdateUser")]
        //public bool UpdateById(DealViewModel dealViewModel)
        //{
        //    bool isSuccess = .Update(new StandartsDTO
        //    {
        //        CultureName = standartViewModel.CultureName,
        //        FieldsToCheck = standartViewModel.FieldsToCheck,
        //        Id = standartViewModel.Id
        //    });
        //    return isSuccess;
        //}
    }
}
