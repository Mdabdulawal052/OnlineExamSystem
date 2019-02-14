using ExamSystemModel.Models;
using ExamSystemRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemBLL.BLL
{
    public class UserBLL
    {
        UserRepository _userRepository=new UserRepository();
        public bool Add(UserLogin userLogin)
        {
            bool isSave = _userRepository.Add(userLogin);
            return isSave;
        }

        public bool Update(UserLogin userLogin)
        {
            bool isSaved = _userRepository.Update(userLogin);
            return isSaved;
        }

        public bool Remove(UserLogin userLogin)
        {
            bool isDelete = _userRepository.Remove(userLogin);
            return isDelete;
        }

        public List<UserLogin> GetAll()
        {
            List<UserLogin> userList = _userRepository.GetAll();
            return userList;
        }


        public UserLogin GetById(int id)
        {
            UserLogin user = _userRepository.GetById(id);
            return user;
        }
    }
}
