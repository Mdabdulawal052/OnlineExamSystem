using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemDataBaseContext.DataBaseContext;
using ExamSystemModel.Models;

namespace ExamSystemRepository.Repository
{
    public class ExamTypeRepository
    {
        OnlineExamDb db = new OnlineExamDb();
        public List<ExamType> GetAll()
        {
            return db.ExamTypess.ToList();
        }
    }
}
