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
    public class ExamRepository
    {
        OnlineExamDb db = new OnlineExamDb();
        public bool Add(Exam exam)
        {

            db.Examss.Add(exam);
            return db.SaveChanges() > 0;
        }

        public bool Update(Exam exam)
        {

            db.Entry(exam).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(Exam exam)
        {
            db.Examss.Remove(exam);
            return db.SaveChanges() > 0;
        }
        public Exam GetById(int id)
        {

            return db.Examss.Find(id);

        }

        public List<Exam> GetAll()
        {
            List<Exam> exam=db.Examss.ToList();
            return exam;
        }

        public IQueryable<Exam> QuarableExam()
        {
            return db.Examss.AsQueryable();
            
        }
       
        
    }
}
