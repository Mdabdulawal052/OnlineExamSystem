using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class BatchBLL
    {
        BatchRepository _batchRepository=new BatchRepository();
        public bool Add(Batch batch)
        {
            bool isSave = _batchRepository.Add(batch);
            return isSave;
        }

        public IQueryable<Batch> QueryableBatches()
        {
            return _batchRepository.QuarableBatches();
        }

        public bool Update(Batch batch)
        {
            bool isSaved = _batchRepository.Update(batch);
            return isSaved;
        }

        public bool Remove(Batch batch)
        {
            bool isDelete = _batchRepository.Remove(batch);
            return isDelete;
        }

        public List<Batch> GetAll()
        {
            List<Batch> batchList = _batchRepository.GetAll();
            return batchList;
        }


        public Batch GetById(int id)
        {
            Batch batch = _batchRepository.GetById(id);
            return batch;
        }
    }

}
