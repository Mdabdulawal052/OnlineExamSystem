using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models
{
    public class QuestionOptionCV
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public bool checkbox { get; set; }
        public int Sl { get; set; }
        public int QuestionId { get; set; }
    }
}