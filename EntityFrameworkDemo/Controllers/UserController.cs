using EntityFrameworkDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;
        UserCrud db;
        public UserController(ApplicationDbContext context)
        {
            this.context = context;
            db = new UserCrud(this.context);
        }
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }

        //[HttpPost]

        //public ActionResult Login(User user)
        //{


            //try
            //{
            //    int response = db.ValidateUser(user);
            //    if (response >= 1)
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    else
            //    {
            //        ViewBag.ErrorMsg = "Something went wrong";
            //        return View();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    ViewBag.ErrorMsg = ex.Message;
            //    return View();
            //}

        //}
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            try
            {
                int response = db.AddUser(user);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
        }


        




   
}
