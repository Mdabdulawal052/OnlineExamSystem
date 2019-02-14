using ExamSystemDataBaseContext.DataBaseContext;
using ExamSystemModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemRepository.Repository
{
    public class AdminRepository
    {
         OnlineExamDb db = new OnlineExamDb();
        public bool Add(AdminLogIn adminLogin)
        {

            db.Admins.Add(adminLogin);
            return db.SaveChanges() > 0;
        }

        public bool Update(AdminLogIn adminLogin)
        {

            db.Entry(adminLogin).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(AdminLogIn adminLogin)
        {
            db.Admins.Remove(adminLogin);
            return db.SaveChanges() > 0;
        }
        public AdminLogIn GetById(int id)
        {
            return db.Admins.Find(id);

        }

        public List<AdminLogIn> GetAll()
        {
            return db.Admins.ToList();
        }
    }
}
