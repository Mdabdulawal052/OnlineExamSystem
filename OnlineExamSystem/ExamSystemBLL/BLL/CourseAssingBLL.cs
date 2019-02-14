using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class CourseAssingBLL
    {
        CourseAssingRepository _courseAssRepository=new CourseAssingRepository();
        public bool Add(CourseAssing courseAss)
        {
            bool IsSave = _courseAssRepository.Add(courseAss);
            return IsSave;
        }

        public bool Update(CourseAssing courseAss)
        {
            bool isSaved = _courseAssRepository.Update(courseAss);
            return isSaved;
        }

        public bool Remove(CourseAssing courseAss)
        {
            bool isDelete = _courseAssRepository.Remove(courseAss);
            return isDelete;
        }
        public List<CourseAssing> GetAll()
        {
            List<CourseAssing> courseAsstList = _courseAssRepository.GetAll();
            return courseAsstList;
        }


        public CourseAssing GetById(int id)
        {
            CourseAssing courseAssing = _courseAssRepository.GetById(id);
            return courseAssing;
        }
    }
}
