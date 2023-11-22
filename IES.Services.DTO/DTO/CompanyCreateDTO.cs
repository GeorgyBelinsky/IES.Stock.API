using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Services.DTO.DTO
{
    public class CompanyCreateDTO
    {
        public int CompanyId { get; set; }
        public int CountOfStock { get; set; }
        public int StockPrice { get; set; }
        public string StockCode { get; set; }
        public int Resources { get; set; }
    }
}
