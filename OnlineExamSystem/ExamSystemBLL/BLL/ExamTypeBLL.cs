using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class ExamTypeBLL
    {
        ExamTypeRepository _examTypeRepository=new ExamTypeRepository();

        public List<ExamType> GetAll()
        {
            return _examTypeRepository.GetAll();
        }
    }
}
