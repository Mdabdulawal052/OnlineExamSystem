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
    public class ParticipantRepository
    {
        OnlineExamDb db = new OnlineExamDb();
        public bool Add(Participant participant)
        {

            db.Participantss.Add(participant);
            return db.SaveChanges() > 0;
        }

        public bool Update(Participant participant)
        {

            db.Entry(participant).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(Participant participant)
        {
            db.Participantss.Remove(participant);
            return db.SaveChanges() > 0;
        }
        public Participant GetById(int id)
        {
            return db.Participantss.Find(id);

        }

        public IQueryable<Participant> QueryableParticipants()
        {
            return db.Participantss.AsQueryable();
        }
        public List<Participant> GetAll()
        {
            return db.Participantss.ToList();
        }
    }
}
