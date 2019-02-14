using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ExamSystemBLL.BLL;
using ExamSystemModel.Models;
using OnlineExamSystem.Models;
using OnlineExamSystem.Models.JoinModel;

namespace OnlineExamSystem.Controllers
{
    public class QuestionController : Controller
    {
        OrganizationBLL _organizationBll = new OrganizationBLL();
        QuestionTypeBLL _questionTypeBll = new QuestionTypeBLL();
        CourseBLL _courseBll = new CourseBLL();
        ExamBLL _examBll = new ExamBLL();
        ExamTypeBLL _examTypeBll = new ExamTypeBLL();
        QuestionBLL _questionBll=new QuestionBLL();
        QOptionBLL _optionBll = new QOptionBLL();
        public ActionResult Create()
        {
            //var model=new QuestionCreateForView
            //{
            //    CourSelectListItems = GetDefaultSelectListItem(),
            //    OrganizationSelectListItems = _organizationBll.GetAll()
            //        .Select(c => new SelectListItem()
            //        {
            //            Value = c.Id.ToString(),
            //            Text = c.Name
            //        })

                
            //};
            var model=new QuestionCreateForView();
            List<Organization> olist = _organizationBll.GetAll();
            ViewBag.QuestionOrganizationList = new SelectList(olist, "Id", "Name");
            ViewBag.CourseId = new SelectList(new List<Course>(), "Id", "Name");
            ViewBag.ExamId = new SelectList(new List<Exam>(), "Id", "Name");
            model.QuestionTypeSelectListItems = _questionTypeBll.GetAll().Select(c => new SelectListItem()
                {Value = c.Id.ToString(), Text = c.QuestionTypes});
           
            return View(model);
        }
        [HttpPost]
        public JsonResult Create(QuestionCreateForView model)
        {

            
            var modelNew = Mapper.Map<Question>(model);
            var isSaved = _questionBll.Add(modelNew);
            model=new QuestionCreateForView();
            if (isSaved)
            {
                ViewBag.SMsg = "Saved Successfully";
               
                    
            }
            
           

            List<Organization> olist = _organizationBll.GetAll();
                ViewBag.QuestionOrganizationList = new SelectList(olist, "Id", "Name", model.OrganizationId);//If I not Write OrganizationId It also work Bcz Model Also contain OrganizationId
                //var courseId = course.Id;
                List<Course> clist = _courseBll.GetAll();
                ViewBag.QuestionCourseList = new SelectList(clist, "Id", "Name", model.CourseId);
            List<Exam> elist = _examBll.GetAll();
                ViewBag.QuestionExamList = new SelectList(elist, "Id", "Topic", model.ExamId);
            model.QuestionTypeSelectListItems = _questionTypeBll.GetAll().Select(c => new SelectListItem()
                {Value = c.Id.ToString(), Text = c.QuestionTypes});
            model.WriteQuestion = "";

            var jsonData = "success";
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataForQuestion(QuestionCreateForView model)
        {
            var question=model.WriteQuestion;
            var isGet=_questionTypeBll.GetAll().SingleOrDefault(e=>e.Id == model.OptionTypeId);
                
            //var questionNew=_questionBll.GetAll().SingleOrDefault(e=>e.QuestionOrder==model.QuestionOrder && e.ExamId==model.ExamId);
            string qType="";
            //int optionCount=0;
            if( isGet !=null )
            {
                qType=isGet.QuestionTypes;
                
            }
            var order=model.QuestionOrder;
            QuestionTable questionTable=new QuestionTable();
            questionTable.Order=order;
            questionTable.QuestionName=question;
            questionTable.OptionType=qType;
      
            var jsonData=questionTable;

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetQuesOrderByExamId(int examId)
        {
            var datalist=_questionBll.GetAll().LastOrDefault(e=>e.ExamId==examId);
            var jsonData=0;
            if (datalist != null)
            {
                jsonData = datalist.QuestionOrder +1;
            }
            
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<SelectListItem> GetDefaultSelectListItem()
        {
            return new List<SelectListItem> { new SelectListItem { Value = "", Text = "---Select--- " } };
        }

        public JsonResult GetCourseByOrganizationId(int organizationId)
        {
            var datalist = _courseBll.GetAll().Where(c => c.Organizationid == organizationId).ToList();
            var jsonData = datalist.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetExamByCourseId(int courseId)
        {
            var model=new ExamEntryForView();
            var datalist = _examBll.GetAll().Where(c => c.CourseId == courseId).ToList();
            var jsonData = datalist.Select(c => new { c.Id,c.Topic});
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetQuestionByExamId(int parmsExamId)
        {
            var model=new ExamEntryForView();
            var datalist = _questionBll.GetById(parmsExamId);
            if (datalist!=null)
            {

            }
            var jsonData="";
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
       
    }
}