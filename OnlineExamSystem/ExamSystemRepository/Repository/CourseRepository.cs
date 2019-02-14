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
    public class CourseRepository
    {
        OnlineExamDb db = new OnlineExamDb();
        public bool Add(Course course)
        {

            db.Coursess.Add(course);
            return db.SaveChanges() > 0;
        }

        public bool Update(Course course)
        {

            db.Entry(course).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(Course course)
        {
            db.Coursess.Remove(course);
            return db.SaveChanges() > 0;
        }
        public Course GetById(int id)
        {
            return db.Coursess.Find(id);

        }

        public IQueryable<Course> QuarableCourses()
        {
            return db.Coursess.AsQueryable();
        }
        public List<Course> GetAll()
        {
            return db.Coursess.ToList();
        }
    }
}
