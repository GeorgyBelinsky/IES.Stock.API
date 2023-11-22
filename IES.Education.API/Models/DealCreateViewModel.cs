using IES.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IES.Education.API.Models
{
    public class DealCreateViewModel
    {
        public int DealId { get; set; }
        public int CountOfStockDeal { get; set; }
        public int? CompanyId { get; set; }
        public string UserId { get; set; }//user id
        public DateTime CreateTime { get; set; }
        public int ResultPrice { get; set; }
    }
}
