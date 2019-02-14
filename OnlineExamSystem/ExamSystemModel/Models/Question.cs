using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemModel.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string WriteQuestion { get; set; }
        public double Marks { get; set; }
        public int QuestionOrder { get; set; }

        public int ExamId { get; set; }
        public int OptionTypeId { get; set; }
        public virtual List<QOption> QOptions { get; set; }
    }
}
