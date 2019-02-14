using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;
using ExamSystemRepository.Repository;

namespace ExamSystemBLL.BLL
{
    public class OrganizationBLL
    {
        OrganizationRepository _organizationRepository=new OrganizationRepository();
        public bool Add(Organization organization)
        {
            bool IsSave = _organizationRepository.Add(organization);
            return IsSave;
        }

        public bool Update(Organization organization)
        {
            return _organizationRepository.Update(organization);
        }

        public bool Remove(Organization organization)
        {
            return _organizationRepository.Remove(organization);
        }

        public List<Organization> GetAll()
        {
            List<Organization> organizationList = _organizationRepository.GetAll();
            return organizationList;
        }




        public Organization GetById(int id)
        {
            Organization organization = _organizationRepository.GetById(id);
            return organization;
        }
    }
}
