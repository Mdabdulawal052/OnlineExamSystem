using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemModel.Models
{
    public class QOption
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public bool checkbox { get; set; }
        public int Sl { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
