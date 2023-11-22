using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IES.Education.API.Models
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public List<MapViewModel> Answers { get; set; }
    }
}
