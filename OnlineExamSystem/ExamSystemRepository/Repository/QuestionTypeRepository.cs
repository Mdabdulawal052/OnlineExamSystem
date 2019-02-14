using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemDataBaseContext.DataBaseContext;
using ExamSystemModel.Models;

namespace ExamSystemRepository.Repository
{
    public class QuestionTypeRepository
    {
        OnlineExamDb db = new OnlineExamDb();
        public List<QuestionType> GetAll()
        {
            return db.QuestionTypes.ToList();
        }
    }
}
