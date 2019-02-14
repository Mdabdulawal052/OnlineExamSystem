using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ExamSystemBLL.BLL;
using ExamSystemModel.Models;
using OnlineExamSystem.Models;


namespace OnlineExamSystem.Controllers
{
    public class OrganizationController : Controller
    {
        OrganizationBLL _organizationBll=new OrganizationBLL();
        CourseBLL _courseBll=new CourseBLL();
        BatchBLL _batchBll=new BatchBLL();
        ParticipantBLL _participantBll= new ParticipantBLL();
        TrainerBLL _trainerBll=new TrainerBLL();
        // GET: Organization
        private static int _orgId;
        
        public ActionResult Dashbord()
        {
             if (Session["AdminData"] == null)
            {
                return RedirectToAction("Login","Admin");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Index()
        {
            if (Session["AdminData"] == null)
            {
                return RedirectToAction("Login","Admin");
            }
            else
            {
                 OrganizationCreateForView model=new OrganizationCreateForView();
                model.Code = getAutocode();
                return View(model);
            }
           
        }

        [HttpPost]
        public ActionResult Index(OrganizationCreateForView model, HttpPostedFileBase Logo)
        {
            var organization = Mapper.Map<Organization>(model);

            if (_organizationBll.GetAll().Any(e => e.Name == model.Name))
            {
                ModelState.AddModelError("Name","This Organization Is Already Assign");
            }
            
            if (ModelState.IsValid)
            {
                
                    string fileName = Path.GetFileName(Logo.FileName);
                    string extention = Path.GetExtension(Logo.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    organization.Logo = "~/Image/" + fileName;
                    string filePath = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    Logo.SaveAs(filePath);

                    var isAdded = _organizationBll.Add(organization);

                    return RedirectToAction("Details", new { id = organization.Id });
                
            }


            return View(model);

        }

        public ActionResult Details(int id)
        {
            if (Session["AdminData"] == null)
            {
                return RedirectToAction("Login","Admin");
            }
            else
            {
            _orgId = id;
            Organization organization = _organizationBll.GetById(_orgId);
           
            return View(organization);
            }
        }

        public ActionResult CourseSInOrgnization()
        {
           
            var model = new CourseCreateForView();
            int oId = _orgId;
            //int totalParticipant = 0;
            //int totalTrainer = 0;
            model.CourseList = _courseBll.GetAll().Where(c => c.Organizationid == oId).ToList();
            for (int i = 0; i < model.CourseList.Count; i++)
            {

                var id = model.CourseList[i].Id;
                
                model.CourseList[i].TotalParticipant = _participantBll.GetAll().Count(c => c.CourseId == id);
                model.CourseList[i].TotalTrainer = _trainerBll.GetAll().Count(c => c.CourseId == id);
               
            }
            
            
            return View(model);
        }

        public ActionResult CourseTrianer()
        {
            var oId = _orgId;
            var model = new TrainerCreateForPV();
            model.TrainerList = _trainerBll.GetAll().Where(c => c.OrganizationId == oId).ToList();
           
            
            return View(model);
        }
        public ActionResult CourseParticipant()
        {
            var oId = _orgId;
            var model = new ParticipantCreateForView();
            model.ParticipantListItems = _participantBll.GetAll().Where(c => c.OrganizationId == oId).ToList();
            return View(model);
        }
       

        public int getAutocode()
        {
            
            int code = Convert.ToInt32(23 + DateTime.Now.Second+"1" + DateTime.Now.Millisecond);

            return code;
        }

        [HttpGet]
        public ActionResult Search()
        {
            if (Session["AdminData"] == null)
            {
                return RedirectToAction("Login","Admin");
            }
            else
            {
            
                var model = new OrganizationCreateForView();
                model.Detailsid = _orgId;
                model.OrganizationList = _organizationBll.GetAll();
                for (int i = 0; i < model.OrganizationList.Count; i++)
                {

                    var id = model.OrganizationList[i].Id;
                    var modelCourse = new CourseCreateForView();
                    modelCourse.CourseList = _courseBll.GetAll();
                    model.OrganizationList[i].CourseTotal = _courseBll.QueryableCourse().Count(c => c.Organizationid == id);
                }
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Search(OrganizationCreateForView model)
        {
            var organization = Mapper.Map<Organization>(model);
            //var dataList = organization.Name;
            var dataList = _organizationBll.GetAll();
            if (organization.Name != null)
            {
                dataList = dataList.Where(c => c.Name.ToLower().Contains(organization.Name.ToLower())).ToList();
                //var courseCount=
            }
            if (organization.Address != null)
            {
                dataList = dataList.Where(c => c.Address.ToLower().Contains(organization.Address.ToLower())).ToList();
            }

            if (organization.Code != 0)
            {
                dataList = dataList.Where(c => c.Code == organization.Code).ToList();
            }

            if (organization.ContactNumber !=null)
            {
                dataList = dataList.Where(c => c.ContactNumber == organization.ContactNumber).ToList();
            }

           
            for (int i = 0; i < dataList.Count; i++)
            {

                var id = dataList[i].Id;
                var modelCourse = new CourseCreateForView();
                modelCourse.CourseList = _courseBll.GetAll();
                dataList[i].CourseTotal = _courseBll.QueryableCourse().Count(c => c.Organizationid == id);
            }
            
            model.OrganizationList = dataList;
            

            return View(model);
        }

        public ActionResult OrgDetails(int id)
        {
           
            Organization organization = _organizationBll.GetAll().Single(e=>e.Id==id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }
        public ActionResult OrgEdit(int id)
        {
            Organization organization = _organizationBll.GetAll().Single(e=>e.Id==id);
            
            return View(organization);
           
        }

        [HttpPost]
        public ActionResult OrgEdit(Organization organization)
        {
            
           
            //var model = Mapper.Map<Course>(CourseCV);

            var isSave = _organizationBll.Update(organization);
            if (isSave)
            {
                ViewBag.Smsg = "Saved Successfully.";
            }
            else
            {
                ViewBag.Emsg = "Failed...";
            }
            
            
            return View(organization);
        }
        public ActionResult CourseDetails(int id)
        {
           
            Course course = _courseBll.GetAll().Single(e=>e.Id==id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        public ActionResult Edit(int id)
        {
            Course course = _courseBll.GetAll().Single(e=>e.Id==id);
           
            ViewBag.OrganizationId = new SelectList(_organizationBll.GetAll(), "Id", "Name", course.Organizationid);
           
            return View(course);
           
        }

        [HttpPost]
        public ActionResult Edit(Course CourseCV)
        {
            
           
            //var model = Mapper.Map<Course>(CourseCV);
            
            var isSave = _courseBll.Update(CourseCV);
            if (isSave)
            {
                ViewBag.Smsg = "Saved Successfully.";
            }
            else
            {
                ViewBag.Emsg = "Failed...";
            }
            
            ViewBag.OrganizationId = new SelectList(_organizationBll.GetAll(), "Id", "Name", CourseCV.Organizationid);
            return View(CourseCV);
        }

        public ActionResult ParticipantDetails(int id)
        {
           
            Participant participant = _participantBll.GetAll().Single(e=>e.Id==id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }
        public ActionResult TrainerDetails(int id)
        {
           
            Trainer trainer = _trainerBll.GetAll().Single(e=>e.Id==id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }
        
    }
}