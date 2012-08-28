using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ED_LearnPad_Core.DTOs;
using ED_LearnPad_Core.Services;

namespace Ed_LearnPad.Controllers
{
    public class LoginController : Controller
    {

        /// <summary>
        /// Login the user using the ER web service 
        /// </summary>
        /// <returns>If the user is a valid user or not</returns>
        public JsonResult SignIn(string userName, string password)
        {
            if (Session["CurrentUser"] != null)
            {
                return Json("You Are Already Logged in", JsonRequestBehavior.AllowGet);
            }

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return Json("UserName or Password are empty", JsonRequestBehavior.AllowGet);
            }

            var login = new Login();

            var userDto = login.UserLogin(userName, password);

            if (userDto.UserValidLogin)
                Session["CurrentUser"] = userDto;

            return Json(userDto.UserValidLogin, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Log Out the user from 
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            if (Session["CurrentUser"] == null)
            {
                return RedirectToAction("Index", "Home");s
            }

            return RedirectToAction("Index", "Home");
        }


    }
}
