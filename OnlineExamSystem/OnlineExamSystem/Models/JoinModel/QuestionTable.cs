using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamSystem.Models.JoinModel
{
    public class QuestionTable
    {
        public int Order { get;set;}
        public string QuestionName { get;set;}
        public string OptionType { get;set;}
        public int OptionCount { get;set;}
    }
}