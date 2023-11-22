using FastMapper;
using IES.Education.API.Models;
using IES.Services.DTO.DTO;
using IES.Services.Interfaces.Interfaces;
using IES.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IES.Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [Route("Create")]
        [HttpPost]
        public void Create(CompanyCreateViewModel companyyViewModel)
        {
            companyService.Create(TypeAdapter.Adapt<CompanyCreateDTO>(companyyViewModel));
        }

        [Route("GetCountOfStock")]
        [HttpGet]
        public int GetCountOfStock(int id)
        {
            return companyService.GetCountOfStock(id);
        }

        [HttpGet]
        [Route("GetAllCompanys")]
        public async Task<List<CompanyViewModel>> GetAllCompanies()
        {
            return TypeAdapter.Adapt<List<CompanyViewModel>>(await companyService.GetAllAsync());
        }

        [HttpDelete]
        [Route("DeleteCompany")]
        public bool Delete(int companyId)
        {
            return companyService.Remove(companyId);
        }

        [Route("UpdateStockCount")]
        [HttpPut]
        public void UpdateCompanyStockCount(int companyId, int stockCount)
        {
            companyService.UpdateCompanyStockCount(companyId, stockCount);
        }

        [Route("UpdateStockPrice")]
        [HttpPut]
        public void UpdateCompanyStockPrice(int companyId, int stockPrice)
        {
            companyService.UpdateCompanyStockPrice(companyId, stockPrice);
        }
        [Route("CompanyStockDischarge")]
        [HttpPut]
        public void CompanyStockDischarge(int companyId, int dealid)
        {
            companyService.CompanyStockDischarge(companyId, dealid);
        }

        [Route("GetPriceByAmount")]
        [HttpGet]
        public int GetPriceByAmount(int id, int amount)
        {
            //return TypeAdapter.Adapt<DealViewModel>(await dealService.GetPriceByAmount(id,amount));
            return companyService.GetPriceByAmount(id, amount);
        }

        [Route("CountCompanyPrice")]
        [HttpGet]
        public int CountCompanyPrice(int companyId)
        {
            return companyService.CountCompanyPrice(companyId);
        }
    }
}