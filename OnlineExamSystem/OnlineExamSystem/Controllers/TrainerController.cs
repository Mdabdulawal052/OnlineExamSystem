using System;
using System.Collections.Generic;
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
    public class TrainerController : Controller
    {


        OrganizationBLL _organizationBll = new OrganizationBLL();

        CourseBLL _courseBll = new CourseBLL();
        BatchBLL _batchBll = new BatchBLL();
        TrainerBLL _trainerBll = new TrainerBLL();

        [HttpGet]
        public ActionResult TrainerCreate()
        {
            // var g = _courseBll.GetAll();
            var model = new TrainerCreateForPV
            {
                CourSelectListItems = GetDefaultSelectListItem(),
                OrganiSelectListItems = _organizationBll.GetAll()
                    .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
            };
            //model.Courses = _courseBll.GetAll();

            model.BathcSelectListItems = GetDefaultSelectListItem();

            return View(model);
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

        public JsonResult GetBatchByCourseId(int courseId)
        {
            var datalist = _batchBll.GetAll().Where(c => c.CourseId == courseId).ToList();
            var jsonData = datalist.Select(c => new { c.Id, c.BatchNo });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public ActionResult TrainerCreate()   
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult TrainerCreate(TrainerCreateForPV model, HttpPostedFileBase Img)
        {

            
            if (ModelState.IsValid)
            {
                //var trainer = Mapper.Map<Trainer>(model);
                var trainer=new Trainer()
                {
                    Name = model.Name,
                    ContactNo = model.ContactNo,
                    Email = model.Email,
                    AddLine1 = model.AddLine1,
                    AddLine2 = model.AddLine2,
                    City = model.City,
                    PostCode = model.PostCode,
                    Country = model.Country,
                    Img = model.Img,
                    Lead = model.Lead,
                    OrganizationId = model.OrganizationId,
                    CourseId = model.CourseId,
                    BatchId = model.BatchId
                };
                string fileName = Path.GetFileName(Img.FileName);
                string extention = Path.GetExtension(Img.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                trainer.Img = "~/Image/Trainer/" + fileName;
                string filePath = Path.Combine(Server.MapPath("~/Image/Trainer/"), fileName);
                Img.SaveAs(filePath);

               
                
                var trainerall = _trainerBll.GetAll();
                var Isave = false;
                for (int i = 0; i < trainerall.Count; i++)
                {
                    if ((model.ContactNo == trainerall[i].ContactNo) || (model.Email == trainerall[i].Email))

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

                    var isAdded = _trainerBll.Add(trainer);
                    if (isAdded)
                    {
                        ViewBag.SMsg = "Save Is Successfully";

                    }
                    else
                    {
                        ViewBag.EMsg = "Save Is UnSuccessfully";
                    }
                }

            }

            model=new TrainerCreateForPV();
            model.CourSelectListItems = GetDefaultSelectListItem();
            model.OrganiSelectListItems = _organizationBll.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

            model.BathcSelectListItems = GetDefaultSelectListItem();

            return View(model);

        }
    }
}