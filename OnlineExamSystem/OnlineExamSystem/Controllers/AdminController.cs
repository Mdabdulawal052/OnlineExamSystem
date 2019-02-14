using ExamSystemBLL.BLL;
using ExamSystemModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamSystem.Controllers
{
    public class AdminController : Controller
    {
        AdminBLL _adminBll=new AdminBLL();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login( AdminLogIn adminLogin)
        {
           
            var isRegister=_adminBll.GetAll().Any(x=>x.Email==adminLogin.Email && x.Password==adminLogin.Password && x.IsActive==true);
            if (isRegister==true)
            {
                Session["AdminData"]=adminLogin;
                return RedirectToAction("Dashbord","Organization");
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AdminLogIn adminLogin)
        {
            var isSave=_adminBll.Add(adminLogin);
            if(isSave)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
        
    }
}