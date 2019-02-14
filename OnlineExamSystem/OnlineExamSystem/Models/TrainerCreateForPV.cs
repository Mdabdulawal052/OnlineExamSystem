using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamSystemModel.Models;
using ExamSystemModel.NormalModel;
using OnlineExamSystem.Models.JoinModel;

namespace OnlineExamSystem.Models
{
    public class TrainerCreateForPV
    {
        public int Id { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Enter only alphabets For Name")]
        [StringLength(100,MinimumLength = 4)]
        [Required]
        public string Name { get; set; }
        [RegularExpression(@"^(((\+|00)?880)|0)(\d){10}$",ErrorMessage = "Contact Number Is Not Valid")]
        public string ContactNo { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }
        public string AddLine1 { get; set; }
        public string AddLine2 { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string Country { get; set; }
        [Required]
        public string Img { get; set; }
        public bool Lead { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }
        [Display(Name = "Batch")]
        [Required]
        public int BatchId { get; set; }
       
        
       
        
        
        public Batch Batch { get; set; }
        [NotMapped]
        public int TrainerId { get; set; }
        [NotMapped]
        public virtual List<CourseAssing> courseList { get; set; }
        [NotMapped]
        public IEnumerable<TrinerCourseAssing> TrainerCourseAssList { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> TrainerSelList { get; set; }
        
        [NotMapped]
        public List<Trainer> TrainerList { get; set; }
       
        [NotMapped]

        public virtual List<CourseAssing> CourseAssingList { get; set; }

        
        [NotMapped]
        public virtual List<BatchTrainerAss> BatchTrainerList { get; set; }
        [NotMapped]
        public IEnumerable<Organization> Organizations { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> OrganiSelectListItems { get; set; }
        [NotMapped]
        public List<Course> Courses { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> CourSelectListItems { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BathcSelectListItems { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> TrainerSelectListItems { get; set; }

       
    }
}