using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class ExamBLL
    {
        ExamRepository _examRepository=new ExamRepository();
        public bool Add(Exam exam)
        {
            bool isSave = _examRepository.Add(exam);
            return isSave;
        }

        public IQueryable<Exam> QuarableExam()
        {
            IQueryable<Exam> exam=_examRepository.QuarableExam();
            return exam;
        }

        public bool Update(Exam exam)
        {
            bool isSaved = _examRepository.Update(exam);
            return isSaved;
        }

        public bool Remove(Exam exam)
        {
            bool isDelete = _examRepository.Remove(exam);
            return isDelete;
        }

        public List<Exam> GetAll()
        {
            List<Exam> examList = _examRepository.GetAll();
            return examList;
        }


        public Exam GetById(int id)
        {
            Exam exam = _examRepository.GetById(id);
            return exam;
        }
    }
}
