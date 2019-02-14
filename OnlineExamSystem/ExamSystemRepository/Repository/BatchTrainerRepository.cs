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
    public class BatchTrainerRepository
    {
        OnlineExamDb db = new OnlineExamDb();
        public bool Add(BatchTrainerAss BatchTrainerAss)
        {

            db.BatchTrainerAss.Add(BatchTrainerAss);
            return db.SaveChanges() > 0;
        }

        public bool Update(BatchTrainerAss BatchTrainerAss)
        {

            db.Entry(BatchTrainerAss).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(BatchTrainerAss BatchTrainerAss)
        {
            db.BatchTrainerAss.Remove(BatchTrainerAss);
            return db.SaveChanges() > 0;
        }
        public BatchTrainerAss GetById(int id)
        {
            return db.BatchTrainerAss.Find(id);

        }


        public List<BatchTrainerAss> GetAll()
        {
            return db.BatchTrainerAss.ToList();
        }
    }
}
