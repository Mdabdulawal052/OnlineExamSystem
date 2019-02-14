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
    public class ParticipantController : Controller
    {
        OrganizationBLL _organizationBll = new OrganizationBLL();

        CourseBLL _courseBll = new CourseBLL();
        BatchBLL _batchBll = new BatchBLL();

        ParticipantBLL _participantBll = new ParticipantBLL();
        // GET: /Participant/
        [HttpGet]
        public ActionResult ParticipantCreate()
        {
            var model = new ParticipantCreateForView

            {
                CourSelectListItems = GetDefaultSelectListItem(),
                OrganiSelectListItems = _organizationBll.GetAll()
                    .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
            };

            model.BathcSelectListItems = GetDefaultSelectListItem();
            return View(model);
        }

        private IEnumerable<SelectListItem> GetDefaultSelectListItem()
        {
            return new List<SelectListItem> { new SelectListItem { Value = "", Text = "---Select--- " } };
        }

        [HttpPost]
        public ActionResult ParticipantCreate(ParticipantCreateForView model, HttpPostedFileBase Img)
        {
            var participant = Mapper.Map<Participant>(model);
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(Img.FileName);
                string extention = Path.GetExtension(Img.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                participant.Img = "~/Image/Participant/" + fileName;
                string filePath = Path.Combine(Server.MapPath("~/Image/Participant/"), fileName);
                Img.SaveAs(filePath);

                var mess = "";
                //var contactNo = "";
                //var email = "";
                var isSave = false;
                var participantall = _participantBll.GetAll();

                for (int i = 0; i < participantall.Count; i++)
                {
                    if ((model.ContactNo == participantall[i].ContactNo) || (model.Email == participantall[i].Email))
                    {
                        isSave = true;
                    }
                }

                if (isSave==true)
                {
                    ViewBag.EMsg = "Duplicate";
                }
                else
                {

                    var isAdded = _participantBll.Add(participant);
                    if (isAdded)
                    {
                        ViewBag.SMsg = "Save Is Successfully";

                    }
                    else
                    {
                        ViewBag.EMsg = "Save Is UnSuccessfully";
                    }
                }

                model = new ParticipantCreateForView();
                model.CourSelectListItems = GetDefaultSelectListItem();
                model.OrganiSelectListItems = _organizationBll.GetAll()
                    .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    });

                model.BathcSelectListItems = GetDefaultSelectListItem();

                ViewBag.SmsIs = mess;

            }



            return View(model);
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


        public JsonResult GetAutoCode(string organization)
        {
            var ParticipantList = _participantBll.GetAll();
            int checkCode = 0;
            for (int i = 0; i < ParticipantList.Count; i++)
            {
                checkCode = ParticipantList[i].Id;
            }

            var ch = checkCode + 1;
            string autoId = Convert.ToString(ch);
            string orginalCode = "";
            if (autoId.Length == 1)
            {
                orginalCode = "00" + autoId;

            }

            if (autoId.Length == 2)
            {
                orginalCode = "0" + autoId;
            }

            else
            {
                orginalCode = autoId;

            }
            

            string year = Convert.ToString(DateTime.Now.Year);
            var newYear = year.Substring(2, 2);
            string autoCode = "PRCPT-" + DateTime.Now.Millisecond + newYear + DateTime.Now.Month + orginalCode;
            return Json(autoCode, JsonRequestBehavior.AllowGet);
        }
    }
}