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
    public class TrainerRepository
    {
        OnlineExamDb db = new OnlineExamDb();
        public bool Add(Trainer trainer)
        {

            db.Trainerss.Add(trainer);
            return db.SaveChanges() > 0;
        }

        public bool Update(Trainer trainer)
        {

            db.Entry(trainer).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(Trainer trainer)
        {
            db.Trainerss.Remove(trainer);
            return db.SaveChanges() > 0;
        }
        public Trainer GetById(int id)
        {
            return db.Trainerss.Find(id);

        }

        
        public List<Trainer> GetAll()
        {
            return db.Trainerss.ToList();
        }


        //public IQueryable<TrainerCourseAs> FindAllProducts()
        //{
        //    return from n in db.Participantss
        //           join c in db.CourseAssingss on n.Id equals c.TrainerId
        //           orderby n.Name descending
        //           select new { n.Name, c.LeadTrainer };
        //}
    }
}
