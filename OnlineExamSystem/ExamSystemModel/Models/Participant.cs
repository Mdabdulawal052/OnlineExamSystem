using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemModel.Models
{
    public class Participant
    {
        public int Id { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Enter only alphabets For Name")]
        [StringLength(100,MinimumLength = 5)]
        [Required]
        public string Name { get; set; }
        public string RegNo { get; set; }
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
        public string Profession { get; set; }
        public string HAcademic { get; set; }
        [Required]
        public string Img { get; set; }

        public int CourseId { get; set; }

        public int OrganizationId { get; set; }
        public int BatchId { get; set; }
        
        public Batch Batch { get; set; }
       
        [NotMapped]
        public virtual List<Organization> OrganizationList { get; set; }
    }
}
