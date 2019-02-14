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
    public class UserRepository
    {
         OnlineExamDb db = new OnlineExamDb();
        public bool Add(UserLogin userLogin)
        {

            db.users.Add(userLogin);
            return db.SaveChanges() > 0;
        }

        public bool Update(UserLogin userLogin)
        {

            db.Entry(userLogin).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(UserLogin userLogin)
        {
            db.users.Remove(userLogin);
            return db.SaveChanges() > 0;
        }
        public UserLogin GetById(int id)
        {
            return db.users.Find(id);

        }

        public List<UserLogin> GetAll()
        {
            return db.users.ToList();
        }
    }
}
