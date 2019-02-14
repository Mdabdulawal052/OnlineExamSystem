using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class TrainerBLL
    {
        TrainerRepository _trainerRepository=new TrainerRepository();
        public bool Add(Trainer trainer)
        {
            bool IsSave = _trainerRepository.Add(trainer);
            return IsSave;
        }

        public bool Update(Trainer trainer)
        {
            bool isSaved = _trainerRepository.Update(trainer);
            return isSaved;
        }

        public bool Remove(Trainer trainer)
        {
            bool isDelete = _trainerRepository.Remove(trainer);
            return isDelete;
        }

        

        public List<Trainer> GetAll()
        {
            List<Trainer> trainerList = _trainerRepository.GetAll();
            return trainerList;
        }


        public Trainer GetById(int id)
        {
            Trainer trainer = _trainerRepository.GetById(id);
            return trainer;
        }
    }
}
