using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class ExamScheduleBLL
    {
        ExamScheduleRepository _examScheduleRepository=new ExamScheduleRepository();
        public bool Add(ExamSchedule examScedule)
        {
            return _examScheduleRepository.Add(examScedule);
        }

        public bool Update(ExamSchedule examScedule)
        {

            return _examScheduleRepository.Update(examScedule);
        }

        public bool Remove(ExamSchedule examScedule)
        {
            return _examScheduleRepository.Remove(examScedule);
        }
        public IQueryable<ExamSchedule> QuarableScheduleExam()
        {
            return _examScheduleRepository.QuarableScheduleExam();
        }
    }
}
