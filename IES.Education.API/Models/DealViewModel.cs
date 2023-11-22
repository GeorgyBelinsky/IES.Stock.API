using IES.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IES.Education.API.Models
{
    public class DealViewModel
    {
        public int DealId { get; set; }
        public int CountOfStockDeal { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public User Id { get; set; }
    }
}