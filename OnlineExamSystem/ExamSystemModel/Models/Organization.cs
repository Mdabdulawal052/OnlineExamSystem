using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemModel.Models
{
    public class Organization
    {
        public int Id { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Enter only alphabets For Name")]
        [Required]
        public string Name { get; set; }
        public int Code { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^(((\+|00)?880)|0)(\d){10}$",ErrorMessage = "Contact Number Is Not Valid")]
        public string ContactNumber { get; set; }
        public string About { get; set; }
        public string Logo { get; set; }

        public ICollection<Course> Courses { get; set; }
        [NotMapped]
        public int CourseTotal { get; set; }
    }
}
