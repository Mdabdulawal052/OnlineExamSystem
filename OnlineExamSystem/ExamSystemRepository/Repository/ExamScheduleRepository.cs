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
    public class ExamScheduleRepository
    {
        OnlineExamDb db = new OnlineExamDb();
        public bool Add(ExamSchedule examScedule)
        {

            db.ExamSchedules.Add(examScedule);
            return db.SaveChanges() > 0;
        }

        public bool Update(ExamSchedule examScedule)
        {

            db.Entry(examScedule).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(ExamSchedule examScedule)
        {
            db.ExamSchedules.Remove(examScedule);
            return db.SaveChanges() > 0;
        }

        public IQueryable<ExamSchedule> QuarableScheduleExam()
        {
            return db.ExamSchedules.AsQueryable();
        }
        public ExamSchedule GetExamSchedule(int id)
        {
            return db.ExamSchedules.Find(id);
        }
    }
}
