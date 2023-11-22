using IES.Services.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Services.Interfaces.Interfaces
{
    public interface ICompanyService
    {
        public CompanyDTO GetById(int id);
        public int GetCountOfStock(int id);
        public void Create(CompanyCreateDTO companyDTO);
        List<CompanyDTO> GetAllCompanies();
        public IEnumerable<CompanyDTO> GetAll();
        public Task<IEnumerable<CompanyDTO>> GetAllAsync();
        public bool Remove(int companyId);
        public void UpdateCompanyStockCount(int companyId, int stockCount);
        public void UpdateCompanyStockPrice(int companyId, int stockPrice);
        public void CompanyStockDischarge(int companyId, int dealId);
        public int GetPriceByAmount(int id, int amount);
        public int CountCompanyPrice(int companyId);

        //Task<List<CompanyDTO>> GetCompanies();
        //Task<CompanyDTO> GetCompaniesWithDeals(int companyId);

        //public void UpdateCountOfStock(int id);
        //public CompanyDTO GetCountOfStock(int id);
    }
}
