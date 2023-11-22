using IES.Domain.Entities.Models;
using IES.Services.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Services.Interfaces.Interfaces
{
    public interface IDealService
    {
        public void Create(DealCreateDTO dealDTO);
        public int GetPrice(int id);
        IEnumerable<DealDTO> GetAll();
        Task<IEnumerable<DealDTO>> GetAllAsync();
        //IEnumerable<DealDTO> GetDealsById(int Id);
        public List<Deal> GetByUserId(string Id);
        public List<Deal> GetByCompanyId(int Id);
        public void UpdateUserDealsList(int dealId);
        public Task<bool> ConfirmDeal(int dealId);

    }
}