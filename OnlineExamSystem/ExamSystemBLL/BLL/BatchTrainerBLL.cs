using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class BatchTrainerBLL
    {
        BatchTrainerRepository _batchtrainerRepository = new BatchTrainerRepository();
        public bool Add(BatchTrainerAss batchTrainerAss)
        {
            bool IsSave = _batchtrainerRepository.Add(batchTrainerAss);
            return IsSave;
        }

        public bool Update(BatchTrainerAss batchTrainerAss)
        {
            bool isSaved = _batchtrainerRepository.Update(batchTrainerAss);
            return isSaved;
        }

        public bool Remove(BatchTrainerAss batchTrainerAss)
        {
            bool isDelete = _batchtrainerRepository.Remove(batchTrainerAss);
            return isDelete;
        }
        public List<BatchTrainerAss> GetAll()
        {
            List<BatchTrainerAss> courseAsstList = _batchtrainerRepository.GetAll();
            return courseAsstList;
        }


        public BatchTrainerAss GetById(int id)
        {
            BatchTrainerAss courseAssing = _batchtrainerRepository.GetById(id);
            return courseAssing;
        }
    }
}
