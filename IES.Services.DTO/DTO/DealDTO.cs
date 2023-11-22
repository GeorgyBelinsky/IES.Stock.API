using IES.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Services.DTO.DTO
{
    public class DealDTO
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

//public int CourseId { get; set; }
//public string CourseDescription { get; set; }
//public int UserGroupId { get; set; }
//public UserGroupDTO UserGroup { get; set; }



//public int QuizId { get; set; }
//public DateTime StartDate { get; set; }
//public DateTime EndDate { get; set; }
//public List<QuestionDTO> Questions { get; set; }

//public int CourseId { get; set; }
//public CourseDTO Course { get; set; }