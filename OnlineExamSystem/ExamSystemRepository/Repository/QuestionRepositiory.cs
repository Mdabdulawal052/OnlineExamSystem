using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemDataBaseContext.DataBaseContext;
using ExamSystemModel.Models;

namespace ExamSystemRepository.Repository
{
    public class QuestionRepositiory
    {
        OnlineExamDb db = new OnlineExamDb();
        public List<Question> GetAll()
        {
            return db.Questions.ToList();
        }
        public bool Add(Question question)
        {

            db.Questions.Add(question);
            return db.SaveChanges() > 0;
        }

        public bool Update(Question question)
        {

            db.Entry(question).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(Question question)
        {
            db.Questions.Remove(question);
            return db.SaveChanges() > 0;
        }
        public Question GetById(int id)
        {
            return db.Questions.Find(id);

        }

        
       
    }
}
