using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemDataBaseContext.DataBaseContext;
using ExamSystemModel.Models;

namespace ExamSystemRepository.Repository
{
    public class QOptionRepository
    {
        OnlineExamDb db = new OnlineExamDb();
        public List<QOption> GetAll()
        {
            return db.QOptions.ToList();
        }
    }
}
