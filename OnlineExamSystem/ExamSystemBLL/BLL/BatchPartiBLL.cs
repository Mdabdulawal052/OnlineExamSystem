using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class BatchPartiBLL
    {
        BatchPartiRepository _batchPartiRepository=new BatchPartiRepository();
        public bool Add(BatchParticipantAss batchPartiAss)
        {
            bool IsSave = _batchPartiRepository.Add(batchPartiAss);
            return IsSave;
        }

        public bool Update(BatchParticipantAss batchPartiAss)
        {
            bool isSaved = _batchPartiRepository.Update(batchPartiAss);
            return isSaved;
        }

        public bool Remove(BatchParticipantAss batchPartiAss)
        {
            bool isDelete = _batchPartiRepository.Remove(batchPartiAss);
            return isDelete;
        }
        public List<BatchParticipantAss> GetAll()
        {
            List<BatchParticipantAss> courseAsstList = _batchPartiRepository.GetAll();
            return courseAsstList;
        }


        public BatchParticipantAss GetById(int id)
        {
            BatchParticipantAss courseAssing = _batchPartiRepository.GetById(id);
            return courseAssing;
        }
    }
}
