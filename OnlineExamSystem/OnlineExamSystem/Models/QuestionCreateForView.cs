using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamSystemModel.Models;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineExamSystem.Models.JoinModel;

namespace OnlineExamSystem.Models
{
    public class QuestionCreateForView
    {
        public int Id { get; set; }
        public string WriteQuestion { get; set; }
        public double Marks { get; set; }
        public int QuestionOrder { get; set; }
        [NotMapped]
        public string Option { get; set; }
        [NotMapped]
        public bool checkbox { get; set; }
        [NotMapped]
        public int Sl { get; set; }
        [NotMapped]
        public string RadioResult { get; set; }
        public int QuestionId { get; set; }
        public virtual List<QOption> QOptions { get; set; }
        [Display(Name = "Exam")]
        public int ExamId { get; set; }
        [Display(Name = "Option")]
        public int OptionTypeId { get; set; }
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }
        public IEnumerable<SelectListItem> OrganizationSelectListItems { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public IEnumerable<SelectListItem> CourSelectListItems { get; set; }
        public IEnumerable<SelectListItem> ExamSelectListItems { get; set; }
        [Display(Name = "QuestionType")]
        public int QuestionTypeId { get; set; }
        public IEnumerable<SelectListItem> QuestionTypeSelectListItems { get; set; }
        [NotMapped]
        public QuestionTable questionTable { get;set;}
    }
}