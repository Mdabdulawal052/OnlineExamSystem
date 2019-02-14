using ExamSystemModel.Models;
using ExamSystemRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemBLL.BLL
{
    public class AdminBLL
    {
        AdminRepository _adminRepository=new AdminRepository();
        public bool Add(AdminLogIn adminLogin)
        {
            bool isSave = _adminRepository.Add(adminLogin);
            return isSave;
        }

        public bool Update(AdminLogIn adminLogin)
        {
            bool isSaved = _adminRepository.Update(adminLogin);
            return isSaved;
        }

        public bool Remove(AdminLogIn adminLogin)
        {
            bool isDelete = _adminRepository.Remove(adminLogin);
            return isDelete;
        }

        public List<AdminLogIn> GetAll()
        {
            List<AdminLogIn> adminList = _adminRepository.GetAll();
            return adminList;
        }


        public AdminLogIn GetById(int id)
        {
            AdminLogIn admin = _adminRepository.GetById(id);
            return admin;
        }
    }
}
