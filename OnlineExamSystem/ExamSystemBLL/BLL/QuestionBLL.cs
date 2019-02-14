using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
   public class QuestionBLL
    {
        QuestionRepositiory _questionRepositiory=new QuestionRepositiory();
        public List<Question> GetAll()
        {
            return _questionRepositiory.GetAll();
        }
        public bool Add(Question question)
        {
            bool isSave = _questionRepositiory.Add(question);
            return isSave;
        }

       

        public bool Update(Question question)
        {
            bool isSaved = _questionRepositiory.Update(question);
            return isSaved;
        }

        public bool Remove(Question question)
        {
            bool isDelete = _questionRepositiory.Remove(question);
            return isDelete;
        }

       
        public Question GetById(int id)
        {
            Question batch = _questionRepositiory.GetById(id);
            return batch;
        }
    }
}
