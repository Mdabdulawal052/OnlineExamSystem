using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class ParticipantBLL
    {
        ParticipantRepository _participantRepository= new ParticipantRepository();
        public bool Add(Participant participant)
        {
            bool IsSave = _participantRepository.Add(participant);
            return IsSave;
        }

        public bool Update(Participant participant)
        {
            bool isSaved = _participantRepository.Update(participant);
            return isSaved;
        }

        public bool Remove(Participant participant)
        {
            bool isDelete = _participantRepository.Remove(participant);
            return isDelete;
        }

        public IQueryable<Participant> QueryableParticipants()
        {
            return _participantRepository.QueryableParticipants();
        }

        public List<Participant> GetAll()
        {
            List<Participant> participantList = _participantRepository.GetAll();
            return participantList;
        }


        public Participant GetById(int id)
        {
            Participant participant = _participantRepository.GetById(id);
            return participant;
        }
    }
}
