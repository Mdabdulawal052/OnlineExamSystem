using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ExamSystemModel.NormalModel;

namespace OnlineExamSystem.Models.JoinModel
{
    public class TrinerCourseAssing
    {
        public int Id { get; set; }

        //public int CourseId { get; set; }

        public int TrainerId { get; set; }
       
        public bool LeadTrainer { get; set; }
        //public Trainer Trainer { get; set; }
        [NotMapped]
        public string TrinerName { get; set; }

        //public  List<TrinerCourseAssing> TrainerCourseAssList { get; set; }
    }
}