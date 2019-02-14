using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamSystemModel.Models;

namespace OnlineExamSystem.Models
{
    public class CourseCreateForView
    {
        public int Id { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Enter only alphabets For Name")]
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        [Required]
        public int CourseDuration { get; set; }
        public string Credit { get; set; }
        public string OutLine { get; set; }
        public string Tags { get; set; }
        [Display(Name = "Organization")]
        [Required]
        public int Organizationid { get; set; }
        [NotMapped]
        public int CId { get; set; }
        public Organization Organization { get; set; }
        [NotMapped]
        public int TotalParticipant { get; set; }
        [NotMapped]
        public int TotalTrainer { get; set; }
        
        [NotMapped]
        public int CDFrom { get; set; }
        [NotMapped]
        public int CDTo { get; set; }
        [NotMapped]
        public int CCFrom { get; set; }
        [NotMapped]
        public int CCTo { get; set; }

        public virtual List<Batch> Batchs { get; set; }
        public virtual List<Exam> Exams { get; set; }
       
        [NotMapped]
        public virtual IEnumerable<SelectListItem> OrganizationListItems { get; set; }
        [NotMapped]
        public virtual IEnumerable<SelectListItem> TrainerListItems{ get; set; }

        [NotMapped]
        public virtual List<Course> CourseList { get; set; }
        [NotMapped]
        public virtual List<Trainer> TrainerList { get; set; }
        public List<SelectListItem> OrganitionSelectListItem { get; set; }



        //public List<Course> OrganizationList { get; set; }
    }
}