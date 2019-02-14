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
    public class BatchRepository
    {
        OnlineExamDb db = new OnlineExamDb();
        public bool Add(Batch batch)
        {

            db.Batchss.Add(batch);
            return db.SaveChanges() > 0;
        }

        public bool Update(Batch batch)
        {

            db.Entry(batch).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(Batch batch)
        {
            db.Batchss.Remove(batch);
            return db.SaveChanges() > 0;
        }
        public Batch GetById(int id)
        {
            return db.Batchss.Find(id);

        }

        public IQueryable<Batch> QuarableBatches()
        {
            return db.Batchss.AsQueryable();
        }
        public List<Batch> GetAll()
        {
            return db.Batchss.ToList();
        }
    }
}
