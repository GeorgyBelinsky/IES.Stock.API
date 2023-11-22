using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IES.Education.API.Models
{
    public class MapViewModel
    {
        public int AnswerId { get; set; }
        public string AnswerContent { get; set; }
        public bool IsCorrect { get; set; }
    }
}
