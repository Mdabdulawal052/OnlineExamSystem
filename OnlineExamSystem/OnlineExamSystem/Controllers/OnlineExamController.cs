using ExamSystemBLL.BLL;
using ExamSystemModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamSystem.Controllers
{
    public class OnlineExamController : Controller
    {
        UserBLL _userBll=new UserBLL();
        // GET: OnlineExam
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult LogOut()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            var isRegister=_userBll.GetAll().Any(x=>x.Email==userLogin.Email && x.Password==userLogin.Password);
            if (isRegister==true)
            {
                Session["UserData"]=userLogin;
                return RedirectToAction("Index","ExamAttend");
            }
            else
            {
                ViewBag.ErrorMsg ="Name/Email ID and Password is not Exist.";
            }
            return View(userLogin);
        }
        public ActionResult Registrtion()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Registrtion(UserLogin userLogin)
        {
            var isSave=_userBll.Add(userLogin);
            if(isSave)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}