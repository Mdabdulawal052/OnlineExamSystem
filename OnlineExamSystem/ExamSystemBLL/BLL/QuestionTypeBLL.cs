using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class QuestionTypeBLL
    {
        QuestionTypeRepository _questionTypeRepository=new QuestionTypeRepository();
        public List<QuestionType> GetAll()
        {
            return _questionTypeRepository.GetAll();
        }
    }
}
