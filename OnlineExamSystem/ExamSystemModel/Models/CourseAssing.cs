using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemModel.Models
{
    public class CourseAssing
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int TrainerId { get; set; }
       
        public bool LeadTrainer { get; set; }
        public Trainer Trainer { get; set; }
        [NotMapped]
        public string Name { get; set; }
       
       
        //[NotMapped]
        //public virtual List<CourseAssing> CourseAssList { get; set; }
       
    }
}
