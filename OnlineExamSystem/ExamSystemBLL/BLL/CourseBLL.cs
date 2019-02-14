using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class CourseBLL
    {
        CourseRepository _courseRepository=new CourseRepository();

        public bool Add(Course course)
        {
            bool IsSave = _courseRepository.Add(course);
            return IsSave;
        }

        public IQueryable<Course> QueryableCourse()
        {
            return _courseRepository.QuarableCourses();
        }

        public bool Update(Course course)
        {
            bool isSaved = _courseRepository.Update(course);
            return isSaved;
        }

        public bool Remove(Course course)
        {
            bool isDelete = _courseRepository.Remove(course);
            return isDelete;
        }

        public List<Course> GetAll()
        {
            List<Course> courseList = _courseRepository.GetAll();
            return courseList;
        }


        public Course GetById(int id)
        {
            Course course = _courseRepository.GetById(id);
            return course;
        }
    }
}
