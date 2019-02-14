using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemModel.Models
{
    public class Course
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
        [Required]
        public int Organizationid { get; set; }


        public Organization Organization { get; set; }
        public virtual List<Batch> Batchs { get; set; }
        
        public virtual List<Exam> Exams { get; set; }

        [NotMapped]
        public int TotalBatch { get; set; }
        [NotMapped]
        public int TotalParticipant { get; set; }
        [NotMapped]
        public int TotalTrainer { get; set; }
        [NotMapped]
        public  List<Trainer> Trainers { get; set; }
        
        
    }
}
