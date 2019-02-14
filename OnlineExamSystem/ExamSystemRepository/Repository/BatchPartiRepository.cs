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
    public class BatchPartiRepository
    {
        OnlineExamDb db = new OnlineExamDb();
        public bool Add(BatchParticipantAss batchPartiAss)
        {

            db.BatchPartiAss.Add(batchPartiAss);
            return db.SaveChanges() > 0;
        }

        public bool Update(BatchParticipantAss batchPartiAss)
        {

            db.Entry(batchPartiAss).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(BatchParticipantAss batchPartiAss)
        {
            db.BatchPartiAss.Remove(batchPartiAss);
            return db.SaveChanges() > 0;
        }
        public BatchParticipantAss GetById(int id)
        {
            return db.BatchPartiAss.Find(id);

        }


        public List<BatchParticipantAss> GetAll()
        {
            return db.BatchPartiAss.Include(e => e.Participant).ToList();
        }
    }
}
