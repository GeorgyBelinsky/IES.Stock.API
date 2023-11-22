using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IES.Education.API.Models
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }
        public int CountOfStock { get; set; }
        public int StockPrice { get; set; }
        public int RegisterNumber { get; set; }
        public string CompanyName { get; set; }
        public string StockCode { get; set; }
        public int Resources { get; set; }
    }
}
