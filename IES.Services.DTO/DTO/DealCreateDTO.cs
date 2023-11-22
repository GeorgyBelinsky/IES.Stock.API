using IES.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Services.DTO.DTO
{
    public class DealCreateDTO
    {
        public int DealId { get; set; }
        public int CountOfStockDeal { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public string UserId { get; set; }//user id
        public User User { get; set; }
        public DateTime CreateTime { get; set; }
        public int ResultPrice { get; set; }
    }
}

