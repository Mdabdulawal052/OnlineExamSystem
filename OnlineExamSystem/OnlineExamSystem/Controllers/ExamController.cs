using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ExamSystemBLL.BLL;
using ExamSystemModel.Models;
using OnlineExamSystem.Models;

namespace OnlineExamSystem.Controllers
{
    public class ExamController : Controller
    {
        // GET: Exam
        ExamBLL _examEntryBll = new ExamBLL();

        OrganizationBLL _organizationBll = new OrganizationBLL();
        CourseBLL _courseBll = new CourseBLL();

        ExamTypeBLL _examTypeBll = new ExamTypeBLL();





        [HttpGet]
        public ActionResult Create()
        {
            var model = new ExamEntryForView();
            model.OrganizationSelectListItems = _organizationBll.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
            model.ExamTypeList = _examTypeBll.GetAll()
                                            .Select(c => new SelectListItem()
                                            {
                                                Value = c.Examtype.ToString(),
                                                Text = c.ExamtypeName
                                            }).ToList();

            model.CourseSelectListItems = GetDefaultSelectListItem();
            return View(model);

        }
        private List<SelectListItem> GetDefaultSelectListItem()
        {
            return new List<SelectListItem> { new SelectListItem { Value = "", Text = "---Select--- " } };
        }

        public JsonResult GetCourseByOrganizationId(int organizationId)
        {
            var datalist = _courseBll.GetAll().Where(c => c.Organizationid == organizationId).ToList();
            var jsonData = datalist.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(ExamEntryForView model)
        {

            var exam = Mapper.Map<Exam>(model);

            var examall = _examEntryBll.GetAll();
            var Isave = false;
            for (int i = 0; i < examall.Count; i++)
            {
                if ((model.ExamCode == examall[i].ExamCode))

                {
                    Isave = true;
                }

            }

            if (Isave==true)
            {
                ViewBag.EMsg = "Duplicate";
            }
            else
            {

                bool isAdded = _examEntryBll.Add(exam);
                if (isAdded)
                {
                    ViewBag.SMsg = "Save Is Successfully";
                    model = new ExamEntryForView();
                }
                else
                {
                    ViewBag.EMsg = "Save Is UnSuccessfully";
                }
            }
           

            model.OrganizationSelectListItems = _organizationBll.GetAll()
                                                .Select(c => new SelectListItem()
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.Name
                                                });
            model.CourseSelectListItems = _courseBll.GetAll()
                                            .Select(c => new SelectListItem()
                                            {
                                                Value = c.Id.ToString(),
                                                Text = c.Name
                                            });
            model.ExamTypeList = _examTypeBll.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Examtype.ToString(),
                    Text = c.ExamtypeName
                }).ToList();

            return View(model);

        }
    }
}