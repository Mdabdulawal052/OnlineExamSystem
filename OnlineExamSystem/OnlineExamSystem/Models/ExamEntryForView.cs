using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamSystemModel.Models;

namespace OnlineExamSystem.Models
{
    public class ExamEntryForView
    {
        public int Id { get; set; }
        [Required]
        public int ExamCode { get; set; }
        public string Topic { get; set; }

        public int Examtype { get; set; }
       
        [Display(Name = "Full Marks")]
        public int FMarks { get; set; }
        public TimeSpan Duration { get; set; }
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        //[Display(Name = "Organization")]
        //public int OId { get; set; }
        //[Display(Name = "Course")]
        //public int CId { get; set; }
        [NotMapped] 
        public string TypeExam { get; set; }
        public IEnumerable<Exam> ExamtListItems { get; set; }
        public IEnumerable<SelectListItem> CourseSelectListItems { get; set; }
        public IEnumerable<SelectListItem> OrganizationSelectListItems { get; set; }
        public IEnumerable<SelectListItem> ExamTypeList { get; set; }
        public List<Exam> ExamtListItm { get; set; }

        public List<ExamType> ExamTypeTotalList { get; set; }
    }
}