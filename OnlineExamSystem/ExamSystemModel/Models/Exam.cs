using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemModel.Models
{
    public class Exam
    {
        public int Id { get; set; }
        [Required]
        public int ExamCode { get; set; }
        public string Topic { get; set; }
        public int FMarks { get; set; }
        public int Examtype { get; set; }
        public TimeSpan Duration { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
