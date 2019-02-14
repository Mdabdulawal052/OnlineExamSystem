using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamSystemModel.Models;
using OnlineExamSystem.Common;

namespace OnlineExamSystem.Models
{
    public class BatchEntryCreateForView
    {
        public int Id { get; set; }
        [Required]
        public int BatchNo { get; set; }
        public string Description { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:d}",ApplyFormatInEditMode = true)]
        //[DateRange("00/01/2000")]
        public DateTime SDate { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:d}",ApplyFormatInEditMode = true)]
        //[DateRange("01/01/2001")]
        public DateTime EDate { get; set; }
        //public int Organizationid { get; set; }
        [Display(Name = "Course")]
        [Required]
        public int CourseId { get; set; }


        
        public Course Course { get; set; }
        [NotMapped]
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }
        [NotMapped]
        public Organization Organization { get; set; }
        [NotMapped]
        public List<SelectListItem> CourseSelectListItem { get; set; }
        [NotMapped]
        public List<SelectListItem> OrganizationSelectListItem { get; set; }
        public virtual List<Trainer> Trainers { get; set; }
        public virtual List<Participant> Participants { get; set; }
        public virtual List<Batch> BatchList { get; set; }
        public virtual List<Trainer> TrainersList { get; set; }
    }

}