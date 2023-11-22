using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Domain.Entities.Models
{
    public class Deal
    {
        public int DealId { get; set; }
        public int CountOfStockDeal { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsSuccsesful { get; set; }
        public DateTime FinishDate { get; set; }
        public int ResultPrice { get; set; }
    }
}

//public class Course
//{
//    public int CourseId { get; set; }
//    public string CourseDescription { get; set; }
//    public int UserGroupId { get; set; }
//    public UserGroup UserGroup { get; set; }
//}