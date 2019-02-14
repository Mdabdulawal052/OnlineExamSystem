using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class QOptionBLL
    {
        QOptionRepository _qOptionRepository=new QOptionRepository();
        public List<QOption> GetAll()
        {
            return _qOptionRepository.GetAll();
        }
    }
}
