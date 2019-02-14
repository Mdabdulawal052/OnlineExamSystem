using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemDataBaseContext.DataBaseContext;
using ExamSystemModel.Models;

namespace ExamSystemRepository.Repository
{
     
    public class OrganizationRepository
    {
        OnlineExamDb db=new OnlineExamDb();
        public bool Add(Organization organization)
        {

            db.Organizationss.Add(organization);
            return db.SaveChanges() > 0;
        }

        public bool Update(Organization organization)
        {

            db.Entry(organization).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool Remove(Organization organization)
        {
            db.Organizationss.Remove(organization);
            return db.SaveChanges() > 0;
        }

        public Organization GetById(int id)
        {
            return db.Organizationss.Find(id);

        }

        public List<Organization> GetAll()
        {
            return db.Organizationss.ToList();
        }
    }
}
