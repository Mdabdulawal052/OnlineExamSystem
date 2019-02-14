using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using OnlineExamSystem.Common;

namespace ExamSystemModel.Models
{
    public class ExamSchedule
    {
        public int Id { get; set; }
        [DateRange("01/01/2000")]
        public DateTime ScheduleDateTime{ get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int BatchId { get; set; }
    }
}
