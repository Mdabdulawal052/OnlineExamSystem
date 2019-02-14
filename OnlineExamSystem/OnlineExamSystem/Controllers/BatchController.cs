using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ExamSystemBLL.BLL;
using ExamSystemModel.Models;
using ExamSystemModel.NormalModel;
using OnlineExamSystem.Models;
using OnlineExamSystem.Models.JoinModel;

namespace OnlineExamSystem.Controllers
{
    public class BatchController : Controller
    {
        // GET: Batch
        OrganizationBLL _organizationBll = new OrganizationBLL();
        CourseBLL _courseEntryBll = new CourseBLL();
        BatchBLL _batchEntryBll = new BatchBLL();
        CourseAssingBLL _courseAssingBll=new CourseAssingBLL();
        ParticipantBLL _participantBll = new ParticipantBLL();
        TrainerBLL _trainerBll = new TrainerBLL();
        ExamBLL _examBll=new ExamBLL();
        ExamScheduleBLL _examScheduleBll=new ExamScheduleBLL();
        BatchTrainerBLL _batchTrainerBll = new BatchTrainerBLL();
        BatchPartiBLL _batchPartiBll = new BatchPartiBLL();
        private static int _bId;
        //
        // GET: /Batch/
        [HttpGet]
        public ActionResult BatchEntry()
        {
            var batchmodel = new BatchEntryCreateForView();
            batchmodel.OrganizationSelectListItem = _organizationBll
                                            .GetAll()
                                            .Select(c => new SelectListItem()
                                            {
                                                Value = c.Id.ToString(),
                                                Text = c.Name
                                            }).ToList();

            batchmodel.CourseSelectListItem = GetBatchSelectListItem().ToList();
            return View(batchmodel);
        }

        public IEnumerable<SelectListItem> GetBatchSelectListItem()
        {
            return new List<SelectListItem> { new SelectListItem { Value = "", Text = "---Select-----" } };

        }

        public JsonResult getBatchByOrganizationId(int organizationId)
        {
            var dataList = _courseEntryBll.GetAll().Where(c => c.Organizationid == organizationId).ToList();
            var jsonData = dataList.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult BatchEntry(BatchEntryCreateForView model)
        {
            var msg = "Failed";
            if (ModelState.IsValid)
            {

                var course = Mapper.Map<Batch>(model);

                bool isAdded = _batchEntryBll.Add(course);
                if (isAdded)
                {
                    ViewBag.SMsg = "Saved";
                    return RedirectToAction("BatchInfo", new { id = course.Id });
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


            var batchmodel = new BatchEntryCreateForView();
            batchmodel.OrganizationSelectListItem = _organizationBll
                                            .GetAll()
                                            .Select(c => new SelectListItem()
                                            {
                                                Value = c.Id.ToString(),
                                                Text = c.Name
                                            }).ToList();

            batchmodel.CourseSelectListItem = GetBatchSelectListItem().ToList();
            return View(batchmodel);





        }

        public ActionResult BatchInfo(int id)
        {
            _bId = id;
            ViewBag.Id = new SelectList(new List<Organization>(), "Id", "Name");
            ViewBag.TrainerId = new SelectList(new List<Organization>(), "Id", "Name");
            ViewBag.ExamId = new SelectList(new List<Organization>(), "Id", "Name");
            return View();

        }



        public ActionResult BatchNo()
        {
            var model = new BatchEntryCreateForView();
            if (ModelState.IsValid)
            {
                int id = _bId;
                Batch batch = _batchEntryBll.GetById(id);
                var courseId = batch.CourseId;
                var course = _courseEntryBll.GetById(courseId);
                model = Mapper.Map<BatchEntryCreateForView>(batch);
                var organizationId = course.Organizationid;
                model.OrganizationId = organizationId;
                List<Organization> olist = _organizationBll.GetAll();
                ViewBag.BatchOrganizationList = new SelectList(olist, "Id", "Name", organizationId);//If I not Write OrganizationId It also work Bcz Model Also contain OrganizationId
                //var courseId = course.Id;
                List<Course> clist = _courseEntryBll.GetAll();
                ViewBag.BatchCourseList = new SelectList(clist, "Id", "Name", courseId);//If I not Write CourseId It also work Bcz Model Also contain CourseId

            }


            return View(model);
        }

        [HttpPost]
        public ActionResult BatchNo(BatchEntryCreateForView batchEntryCV)
        {
            var model = Mapper.Map<Batch>(batchEntryCV);
            if (ModelState.IsValid)
            {


                var isSaved = _batchEntryBll.Update(model);
                if (isSaved)
                {
                    ViewBag.Smsg = "Updated Successfully";
                }
                else
                {
                    ViewBag.Emsg = "Failed..";
                }
            }


            var modelnew = Mapper.Map<BatchEntryCreateForView>(model);
            var course = _courseEntryBll.GetById(model.CourseId);
            List<Organization> list = _organizationBll.GetAll();
            ViewBag.BatchOrganizationList = new SelectList(list, "Id", "Name", course.Organizationid);
            List<Course> clist = _courseEntryBll.GetAll();
            ViewBag.BatchCourseList = new SelectList(clist, "Id", "Name", model.CourseId);


            return View(modelnew);
        }

        //DropdownListin Batch For AssignParticipants
        public JsonResult AssignParticipants()
        {
            var dataList = _participantBll.GetAll().ToList();
            var jsonData = dataList.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        //DropdownListin Batch For AssignTrainers
        public JsonResult AssignTrainers()
        {
            var dataList = _courseAssingBll.GetAll().ToList();
            var jsonData = dataList.Select(c => new { c.TrainerId, c.Trainer.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        //DropdownListin Batch For Schedule Exam
        public JsonResult ExamSDrop()
        {
            var dataList = _examBll.QuarableExam();
            var jsonData = dataList.Select(c => new { c.Id, c.Topic });
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        //Show data into Assing Participant Page Table
        public JsonResult AssignParticipantTable(int id)
        {
            //int pid = Convert.ToInt32(participantId);
            var isGet = _participantBll.GetById(id);
            
            var dataList = _batchPartiBll.GetAll();
            var jsonData = dataList.Select(x => new BatchParticipantAss() { Id = x.Id, ParticipantId = x.ParticipantId, Profession = isGet.Profession, Name = x.Participant.Name });

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        //Show data into Assing Trainer Page Table
        public JsonResult AssignTrinerTable()
        {
            var dataList = _batchTrainerBll.GetAll();
            var jsonData = dataList.Select(x => new BatchTrainerAss() { Id = x.Id, TrainerId = x.TrainerId});

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
       
        //Insert Data Into BatchParticipant Table
        public PartialViewResult ParticipantASS(ParticipantCreateForView partCV)
        {
            var batchPartAss = new BatchParticipantAss();
            if (_batchPartiBll.GetAll().Any(e => e.ParticipantId == partCV.Id))
            {
                ModelState.AddModelError("Id", "Participant is Already Assign");
             
            }
            else
            {


                batchPartAss.BatchId = _bId;
                batchPartAss.ParticipantId = partCV.Id;
                //courseAss.LeadTrainer = partCV.Lead;
                bool isAdded = _batchPartiBll.Add(batchPartAss);
                if (isAdded)
                {
                    ViewBag.SMsg = "Saved";

                }
                else
                {
                    ViewBag.EMsg = "Failed";
                    ;
                }

            }
           // var dataList = _participantBll.GetAll().ToList();
           //ViewBag.BatchAssPartDrop = dataList.Select(c => new { c.Id, c.Name });
            ViewBag.Id = new SelectList(new List<Organization>(), "Id", "Name");
            return PartialView("~/Views/Shared/Batch/_batchAssignParticipant.cshtml", partCV);
        }
        //Insert Data Into BatchTrainer Table
        public PartialViewResult TrainerAss(TrainerCreateForPV trainerCV)
        {

            var batchTrainerAss = new BatchTrainerAss();
            if (_batchTrainerBll.GetAll().Any(e => e.TrainerId == trainerCV.TrainerId))
            {
                ModelState.AddModelError("TrainerId", "Trainer is Already Assign");
            }
            else
            {

                batchTrainerAss.BatchId = _bId;
                batchTrainerAss.TrainerId = trainerCV.TrainerId;
                batchTrainerAss.LeadTrainer = trainerCV.Lead;
                bool isAdded = _batchTrainerBll.Add(batchTrainerAss);
                if (isAdded)
                {
                    ViewBag.SMsg = "Saved";

                }
                else
                {
                    ViewBag.EMsg = "Failed";
                    ;
                }

            }

            ViewBag.TrainerId = new SelectList(new List<Organization>(), "TrainerId", "Name");
            return PartialView("~/Views/Shared/Batch/_batchAssignTrainer.cshtml", trainerCV);
        }

        public JsonResult ScheduleExam(ExamSchedule examSchedule)
        {
            
            examSchedule.BatchId = _bId;
            Exam examData=new Exam();
            var dataList=new ExamEntryForView();
             dataList=Mapper.Map<ExamEntryForView>(examData);
            if (_examScheduleBll.QuarableScheduleExam()
                .Any(e => e.BatchId == examSchedule.BatchId && e.ExamId == examSchedule.ExamId))
            {
                dataList=null;
            }
            else
            {
               
                var isSaved = _examScheduleBll.Add(examSchedule);
                examData = _examBll.GetById(examSchedule.ExamId);
                dataList=Mapper.Map<ExamEntryForView>(examData);
                if (examData.Examtype == 1003)
                {
                    dataList.TypeExam = "ClassTest";
                }
                else
                {
                    dataList.TypeExam = "LabTest";

                }
            }

            return Json(dataList, JsonRequestBehavior.AllowGet);

        }

    }
}