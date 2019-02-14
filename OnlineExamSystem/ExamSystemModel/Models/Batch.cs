using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamSystem.Common;

namespace ExamSystemModel.Models
{
    public class Batch
    {
        public int Id { get; set; }
        [Required]
        public int BatchNo { get; set; }
        public string Description { get; set; }
        [DateRange("01/01/2000")]
        public DateTime SDate { get; set; }
        [DateRange("01/01/2000")]
        public DateTime EDate { get; set; }
        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public virtual List<Trainer> Trainers { get; set; }
        public virtual List<Participant> Participants { get; set; }

        
    }
}
