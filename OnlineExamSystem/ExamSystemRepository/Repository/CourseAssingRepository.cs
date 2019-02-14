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
    public class CourseAssingRepository
    {
        OnlineExamDb db = new OnlineExamDb();
        public bool Add(CourseAssing courseAss)
        {

            db.CourseAssingss.Add(courseAss);
            return db.SaveChanges() > 0;
        }

        public bool Update(CourseAssing courseAss)
        {

            db.Entry(courseAss).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(CourseAssing courseAss)
        {
            db.CourseAssingss.Remove(courseAss);
            return db.SaveChanges() > 0;
        }
        public CourseAssing GetById(int id)
        {
            return db.CourseAssingss.Find(id);

        }


        public List<CourseAssing> GetAll()
        {
            return db.CourseAssingss.Include(e => e.Trainer).ToList();
        }
    }
}
