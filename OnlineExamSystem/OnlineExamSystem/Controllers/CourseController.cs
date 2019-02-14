using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ExamSystemBLL.BLL;
using ExamSystemDataBaseContext.Migrations;
using ExamSystemModel.Models;
using ExamSystemModel.NormalModel;
using OnlineExamSystem.Models;
using OnlineExamSystem.Models.JoinModel;


namespace OnlineExamSystem.Controllers
{
    public class CourseController : Controller
    {
        CourseBLL _courseBll = new CourseBLL();
        OrganizationBLL _organizationBll = new OrganizationBLL();
        ParticipantBLL _participantBll = new ParticipantBLL();
        TrainerBLL _trainerBll = new TrainerBLL();
        BatchBLL _batchBll = new BatchBLL();
        ExamBLL _examBll = new ExamBLL();
        CourseAssingBLL _courseAssingBll = new CourseAssingBLL();
        ExamTypeBLL _examTypeBll = new ExamTypeBLL();

        private static int cId;
        // GET: Course
        public ActionResult CourseInfo(int id)
        {

            cId = id;
            Course course = _courseBll.GetById(id);
            int orgnizationId = course.Organizationid;
            List<Organization> orglist = _organizationBll.GetAll();
            ViewBag.OrgList = new SelectList(orglist, "Id", "Name",orgnizationId);
            List<Course> list = _courseBll.GetAll().Where(e=>e.Organizationid==orgnizationId).ToList();
            ViewBag.CourseId = new SelectList(list, "Id", "Name",cId);
            //ViewBag.CourseId = new SelectList(new List<Course>(), "Id", "Name");
            ViewBag.Examtype = _examTypeBll.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Examtype.ToString(),
                    Text = c.ExamtypeName
                }).ToList();
            ViewBag.Id = new SelectList(new List<Organization>(), "Id", "Name");
            //    .Select(c => new SelectListItem()
            //    {
            //        Value = c.Id.ToString(),
            //        Text = c.Name
            //    }).ToList();

            return View();
        }


        public ActionResult BasicInfo()
        {
            int id = cId;
            //int id = int.Parse(TempData["age"].ToString());
            Course course = _courseBll.GetById(id);
            int orgnizationId = course.Organizationid;
            List<Organization> list = _organizationBll.GetAll();
            ViewBag.OrganizationList = new SelectList(list, "Id", "Name",orgnizationId);
            var model = Mapper.Map<CourseCreateForView>(course);

            return View(model);
        }
        [HttpPost]
        public ActionResult BasicInfo(CourseCreateForView courseCV)
        {
            //var msg = "Failed";
            var model = Mapper.Map<Course>(courseCV);
            if (ModelState.IsValid)
            {


                var isSaved = _courseBll.Update(model);
                if (isSaved)
                {
                    ViewBag.Smsg = "Updated Successfully";
                }
                else
                {
                    ViewBag.Emsg = "Failed..";
                }
            }

            List<Organization> list = _organizationBll.GetAll();
            ViewBag.OrganizationList = new SelectList(list, "Id", "Name",courseCV.Organizationid);
            var modelnew = Mapper.Map<CourseCreateForView>(model);
            return View(modelnew);
        }


        [HttpPost]
        public PartialViewResult NewAssignTrainer(TrainerCreateForPV trainerCV)
        {
            var courseAss = new CourseAssing();
            if (_courseAssingBll.GetAll().Any(e => e.TrainerId == trainerCV.Id))
            {
                ModelState.AddModelError("Id", "Trainer is Already Assign");
            }
            else
            {
                //if (ModelState.IsValid)
                //{
                int CourseId = cId;


                courseAss.CourseId = CourseId;
                courseAss.TrainerId = trainerCV.Id;
                courseAss.LeadTrainer = trainerCV.Lead;
                bool isAdded = _courseAssingBll.Add(courseAss);
                if (isAdded)
                {
                    ViewBag.SuMsg = "Saved";

                }
                else
                {
                    ViewBag.ErMsg = "Failed";

                }
            }
            //List<CourseAssing> courseAssingsList = _courseAssingBll.GetAll();
            //trainerCV.TrainerCourseAssList = courseAssingsList.Select(x => new TrinerCourseAssing() { Id = x.Id, TrainerId = x.TrainerId,LeadTrainer = x.LeadTrainer,TrinerName = x.Trainer.Name });
            trainerCV.TrainerSelList = _trainerBll.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();


            ViewBag.Id = new SelectList(new List<Organization>(), "Id", "Name");

            return PartialView("~/Views/Shared/Course/_AssignTrainer.cshtml", trainerCV);
        }




        public ActionResult Search()
        {
            var model = new CourseCreateForView();
            int totalParticipant = 0;
            int totalTrainer = 0;
            model.CourseList = _courseBll.GetAll();
            for (int i = 0; i < model.CourseList.Count; i++)
            {
                var courseId = model.CourseList[i].Id;
                model.CourseList[i].TotalBatch = _batchBll.GetAll().Count(c => c.CourseId == courseId);
                model.CourseList[i].TotalParticipant = _participantBll.GetAll().Count(c => c.CourseId == courseId);
                model.CourseList[i].TotalTrainer = _trainerBll.GetAll().Count(c => c.CourseId == courseId);
            }

            model.TotalParticipant = totalParticipant;
            model.TotalTrainer = totalTrainer;



            model.OrganizationListItems = _organizationBll.GetAll().
                                        Select(c => new SelectListItem()
                                        {
                                            Value = c.Id.ToString(),
                                            Text = c.Name
                                        }).ToList(); ;
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(CourseCreateForView courseCV)
        {


            var dataList = _courseBll.GetAll();
            if (courseCV.Name != null)
            {
                dataList = dataList.Where(c => c.Name.ToLower().Contains(courseCV.Name.ToLower())).ToList();

            }
            if (courseCV.Code != null)
            {
                dataList = dataList.Where(c => c.Code == courseCV.Code).ToList();
            }
            if (courseCV.Tags != null)
            {
                dataList = dataList.Where(c => c.Tags.ToLower().Contains(courseCV.Tags.ToLower())).ToList();
            }
            if (courseCV.OutLine != null)
            {
                dataList = dataList.Where(c => c.OutLine.ToLower().Contains(courseCV.OutLine.ToLower())).ToList();
            }


            if (courseCV.CourseDuration != 0)
            {
                dataList = dataList.Where(c => c.CourseDuration == courseCV.CDFrom && c.CourseDuration == courseCV.CCTo).ToList();
            }
            if (courseCV.Credit != null)
            {
                dataList = dataList.Where(c => c.Credit == courseCV.CCFrom.ToString() && c.Credit == courseCV.CCTo.ToString()).ToList();
            }

            if (courseCV.Organizationid != 0)
            {
                dataList = dataList.Where(c => c.Organizationid == courseCV.Organizationid).ToList();
            }
            courseCV.CourseList = dataList;

            for (int i = 0; i < courseCV.CourseList.Count; i++)
            {
                var courseId = courseCV.CourseList[i].Id;
                courseCV.CourseList[i].TotalBatch = _batchBll.GetAll().Count(c => c.CourseId == courseId);
                courseCV.CourseList[i].TotalParticipant = _participantBll.GetAll().Count(c => c.CourseId == courseId);
                courseCV.CourseList[i].TotalTrainer = _trainerBll.GetAll().Count(c => c.CourseId == courseId);
            }

            courseCV.OrganizationListItems = _organizationBll.GetAll().
                Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(courseCV);
        }

        public JsonResult GetCourse(string term)
        {
            List<string> courseNameList;
            courseNameList = _courseBll.GetAll().Where(x => x.Name.StartsWith(term))
                .Select(y => y.Name).ToList();
            return Json(courseNameList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CourseEntry()
        {
            var coursemodel = new CourseCreateForView();
            coursemodel.OrganitionSelectListItem = _organizationBll
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();


            return View(coursemodel);
        }

        [HttpPost]
        public ActionResult CourseEntry(CourseCreateForView model)
        {
            if (_courseBll.GetAll().Any(e => e.Name == model.Name))
            {
                ModelState.AddModelError("Name", "Course is Already Assign");
            }
            var msg = "Failed";
            if (ModelState.IsValid)
            {

                var course = Mapper.Map<Course>(model);

                bool isAdded = _courseBll.Add(course);
                if (isAdded)
                {
                    ViewBag.SMsg = "Saved";

                    return RedirectToAction("CourseInfo", new { id = course.Id });
                }
                else
                {
                    ViewBag.EMsg = "Failed"; ;
                }
            }
            else
            {

                ViewBag.EMsg = msg;
            }




            var coursemodel = new CourseCreateForView();
            coursemodel.OrganitionSelectListItem = _organizationBll
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();



            //coursemodel.OrganizationList = _courseEntryBll.GetAll();

            return View(coursemodel);
        }

        //public PartialViewResult CreateExam()
        //{

        //    ExamEntryForView ExmEntryFV =new ExamEntryForView();
        //    return PartialView("~/Views/Shared/Course/_CreateExam.cshtml", ExmEntryFV);
        //}
        //public IEnumerable<SelectListItem> GetBatchSelectListItem()
        //{
        //    return new List<SelectListItem> { new SelectListItem { Value = "", Text = "----Select---" } };

        //}

        public JsonResult AssignTrainers()
        {
            var dataList = _trainerBll.GetAll().ToList();
            var jsonData = dataList.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        //Plus button PopUp Model
        public ActionResult TrainerCreateByAjax()
        {
            //TrainerCreateForPV trainerCreateForPv=new TrainerCreateForPV();
            //trainerCreateForPv.Organizations = _organizationBll.GetAll();
            List<Organization> orglist = _organizationBll.GetAll();
            ViewBag.OrgListTrainer = new SelectList(orglist, "Id", "Name");
            ViewBag.CourseId = new SelectList(new List<Course>(), "Id", "Name");
            ViewBag.BatchId = new SelectList(new List<Course>(), "Id", "Name");
            return PartialView("~/Views/Shared/Course/_AjaxTrainerCreate.cshtml");
        }

        public JsonResult AssignTrinerTable()
        {
            var dataList = _courseAssingBll.GetAll();
            var jsonData = dataList.Select(x => new TrinerCourseAssing() { Id = x.Id, TrainerId = x.TrainerId, LeadTrainer = x.LeadTrainer, TrinerName = x.Trainer.Name });

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        public JsonResult CreateExamTable()
        {
            var dataList = _examBll.GetAll();
            var jsonData = dataList.Select(x => new Exam() { Id = x.Id, CourseId = x.CourseId,ExamCode = x.ExamCode});

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
       
        
        public JsonResult GetCourseByOrganizationId(int organizationId)
        {
            var dataList = _courseBll.GetAll().Where(c => c.Organizationid == organizationId).ToList();
            var jsonData = dataList.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetBatchByOrganizationId(int organizationId)
        {
            var dataList = _courseBll.GetAll().Where(c => c.Organizationid == organizationId).ToList();
            var jsonData = dataList.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public PartialViewResult CreateExam(ExamEntryForView ExmEntryFV)
        {
            var exam = Mapper.Map<Exam>(ExmEntryFV);

            var dataList = _examBll.GetAll().Where(e=>e.CourseId==ExmEntryFV.CourseId && e.ExamCode==ExmEntryFV.ExamCode);
            if (dataList.Count() > 0)
            {
                ViewBag.EMsg = "data is already here";
            }
            else
            {
                bool isSave = _examBll.Add(exam);
                if (isSave)
                {
                    ViewBag.SMsg = "Saved  Successfully";
                    ExmEntryFV = new ExamEntryForView();
                }
                else
                {
                    ViewBag.EMsg = "Failed..";
                }  
            }
            

            //ViewBag.CourseId = _courseBll.GetAll()
            //    .Select(c => new SelectListItem()
            //    {
            //        Value = c.Id.ToString(),
            //        Text = c.Name
            //    }).ToList();
            ViewBag.Examtype = _examTypeBll.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Examtype.ToString(),
                    Text = c.ExamtypeName
                }).ToList();
            List<Organization> orglist = _organizationBll.GetAll();
            ViewBag.OrgList = new SelectList(orglist, "Id", "Name",ExmEntryFV.OrganizationId);
            List<Course> list = _courseBll.GetAll().Where(e=>e.Organizationid==ExmEntryFV.OrganizationId).ToList();;
            ViewBag.CourseList = new SelectList(list, "Id", "Name",ExmEntryFV.CourseId);
            return PartialView("~/Views/Shared/Course/_CreateExam.cshtml", ExmEntryFV);
        }



        public ActionResult CourseNameInfo()
        {
            Course course = new Course();
            course.Id = cId;
            return View(course);
        }

        public ActionResult CourseName()
        {
            Course course = new Course();
            if (ModelState.IsValid)
            {
                int id = cId; //jodi data redirect hoy then eta lagbe na
                course = _courseBll.GetById(id);
                //var model = Mapper.Map<CourseCreateForView>(course);
            }

            return View(course);

        }

        public ActionResult Outline()
        {
            Course course = new Course();
            if (ModelState.IsValid)
            {
                int id = cId; //jodi data redirect hoy then eta lagbe na
                course = _courseBll.GetById(id);
            }
            

            return View(course);

        }
        public ActionResult ExamInfo()
        {
            int id = cId; //jodi data redirect hoy then eta lagbe na
            var model = new ExamEntryForView();

            model.ExamtListItm = _examBll.GetAll().Where(c => c.CourseId == id).ToList();


            return View(model);

        }
        public ActionResult ParticipantInfoNew()
        {

            int id = cId; //jodi data redirect hoy then eta lagbe na
            var model = new BatchEntryCreateForView();
            var modelNew = new ParticipantCreateForView();

            modelNew.ParticipantListItems = _participantBll.GetAll().Where(c => c.CourseId == id).ToList();


            return View(modelNew);

        }
        public ActionResult TrainerInfoNew()
        {
            int id = cId;
            var model = new BatchEntryCreateForView();
            var modelNew = new TrainerCreateForPV();

            modelNew.TrainerList = _trainerBll.GetAll().Where(c => c.CourseId == id).ToList();


            return View(modelNew);

        }
        public ActionResult List()
        {
            var dataList = _courseBll.GetAll();
            CourseCreateForView courseCV = new CourseCreateForView();
            courseCV.CourseList = dataList;

            for (int i = 0; i < courseCV.CourseList.Count; i++)
            {
                var courseId = courseCV.CourseList[i].Id;
                courseCV.CourseList[i].TotalBatch = _batchBll.GetAll().Count(c => c.CourseId == courseId);
                courseCV.CourseList[i].TotalParticipant = _participantBll.GetAll().Count(c => c.CourseId == courseId);
                courseCV.CourseList[i].TotalTrainer = _trainerBll.GetAll().Count(c => c.CourseId == courseId);
            }



            return View(courseCV);
        }
            public ActionResult Details(int id)
        {

            Course course = _courseBll.GetAll().Single(e => e.Id == id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        public ActionResult Edit(int id)
        {
            Course course = _courseBll.GetAll().Single(e => e.Id == id);

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

    }

}