using AutoMapper;
using ExamSystemBLL.BLL;
using ExamSystemModel.Models;
using OnlineExamSystem.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamSystem.Controllers
{
    public class ExamAttendController : Controller
    {

        OrganizationBLL _organizationBll = new OrganizationBLL();
        CourseBLL _courseBll = new CourseBLL();
        ExamBLL _examBll = new ExamBLL();
        QuestionBLL _questionBll=new QuestionBLL();
        QOptionBLL _qOptionBll=new QOptionBLL();
        ParticipantBLL _participantBll=new ParticipantBLL();
        //private static int Cid;
        // GET: ExamAttend
        public ActionResult Index()
        {
            if (Session["UserData"] == null)
            {
                return RedirectToAction("Login","OnlineExam");
            }
            else
            {
                var model=new QuestionCreateForView();
            List<Organization> olist = _organizationBll.GetAll();
            ViewBag.ExmAttendOrganizationList = new SelectList(olist, "Id", "Name");
            ViewBag.CourseId = new SelectList(new List<Course>(), "Id", "Name");
            ViewBag.ExamId = new SelectList(new List<Exam>(), "Id", "Name");
            return View();
            }
            
        }
        [HttpPost]
        public ActionResult Index(QuestionCreateForView model)
        {

            //List<Organization> olist = _organizationBll.GetAll();
            //ViewBag.ExmAttendOrganizationList = new SelectList(olist, "Id", "Name");
            List<Question>list=_questionBll.GetAll().Where(x=>x.ExamId==model.ExamId).ToList();
            Queue<Question> queue=new Queue<Question>();
            foreach(Question a in list)
            {
                queue.Enqueue(a);
            }
            TempData["question"]=queue;
            
            TempData["course"]=model.CourseId;
            TempData.Keep();
            return RedirectToAction("QuizStart");
            //return RedirectToAction("QuizStart",new { id = model.ExamId });
            
        }
        
        public ActionResult QuizStart()
        {
            Question question =null;
           if (Session["UserData"] == null)
            {
                return RedirectToAction("Login","OnlineExam");
            }
           else
           {
               if(TempData["question"] !=null)
            {
                int Cid=Convert.ToInt32(TempData["course"].ToString());
               
                Queue<Question> qlist=(Queue<Question>)TempData["question"];
                if (qlist.Count > 0)
                {
                    question=qlist.Peek();
                    qlist.Dequeue();
                    TempData["questions"]=qlist;
                    if(TempData["marks"]==null){
                        TempData["marks"]=0;
                    }else{
                        TempData["marks"]=Convert.ToDouble(TempData["marks"].ToString());
                    }
                    
                    TempData.Keep();
                }
                else
                {
                    TempData["courseIdNew"]=Cid;
                     TempData.Keep();
                    return RedirectToAction("EndExam");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
           }
            
            QuestionCreateForView questionCv=Mapper.Map<QuestionCreateForView>(question);
           return View(questionCv);
        }
        //private double _totalMarks=0;
        [HttpPost]
        public ActionResult QuizStart(QuestionCreateForView questionQv)
        {
          
            QOption qOption =new QOption();
            qOption=_qOptionBll.GetAll().SingleOrDefault(x=>x.QuestionId==questionQv.Id && x.Id==questionQv.QuestionId);
            if(questionQv!=null)
            {
                if(qOption.checkbox==true)
                {
                    var dd=Convert.ToDouble(TempData["marks"].ToString());
                    TempData["marks"]=Convert.ToDouble(TempData["marks"].ToString()) + questionQv.Marks;
                   
                }
            }
            TempData.Keep();
            double d= Convert.ToDouble(TempData["marks"].ToString());
            return RedirectToAction("QuizStart");
        }
        public ActionResult EndExam()
        {
            if (TempData["marks"] == null || TempData["courseIdNew"]==null )
            {
                return RedirectToAction("Index");
            }
            ViewBag.Marks=Convert.ToDouble(TempData["marks"].ToString());
            //int Oid =Convert.ToInt32(TempData["organization"].ToString());
            int CId=Convert.ToInt32(TempData["courseIdNew"].ToString());
            Course course=new Course();
             course=_courseBll.GetAll().SingleOrDefault(x=>x.Id==CId);
             if (course != null)
             {
                ViewBag.CourseName= course.Name;
                int Oid= course.Organizationid;
                 Organization organization=new Organization();
                 organization=_organizationBll.GetAll().SingleOrDefault(x=>x.Id==Oid);
                 if (organization != null)
                 {
                  ViewBag.OrganizationName=organization.Name;
                 }
             }
            return View();
        }
        //public ActionResult StartExam(int id,int? page)
        //{
        //    ViewBag.ExamViewId=id;
        //    Question question=new Question();
        //    IPagedList<Question> listQuestion=_questionBll.GetAll().Where(e=>e.ExamId==id).ToPagedList(page ?? 1,3);
        //    return View(listQuestion);
        //}
        //[HttpPost]
        //public ActionResult StartExam(IPagedList<Question> totalQuestion)
        //{
        //    foreach(var i in totalQuestion)
        //    {
        //        var id=i.Id;
        //        var mark=i.Marks;
        //        //var isGet=_qOptionBll.GetAll().Where(e=>e.QuestionId == id);
        //        foreach(var j in i.QOptions){
        //             var isGet=_qOptionBll.GetAll().SingleOrDefault(e=>e.Id == j.Id);
        //             if (isGet!=null)
        //             {
        //                 var result=isGet.checkbox;
        //             }
        //        }
        //    }
        //   return RedirectToAction("StartExam");
        //}
        public ActionResult Result()
        {
             return View();
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
         public JsonResult GetParticipantByCourseId(int courseId)
        {
            var model=new ExamEntryForView();
            var datalist = _participantBll.GetAll().Where(c => c.CourseId == courseId).ToList();
            var jsonData = datalist.Select(c => new { c.Id,c.Name});
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        
    }
}