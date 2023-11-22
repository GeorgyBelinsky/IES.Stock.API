using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Domain.Entities.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public int CountOfStock { get; set; }
        public int StockPrice { get; set; }
        public int RegisterNumber { get; set; }
        public string Email { get; set; }
       // public string Password { get; set; }
        public string CompanyName { get; set; }
        public string StockCode { get; set; }
        public int Resources { get; set; }
        public List<Deal> Deals { get; set; }
    }
}
