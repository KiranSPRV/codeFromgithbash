using AngularJSWithAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularJSWithAPI.ADODAL;

namespace AngularJSWithAPI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Get_AllUsers()
        {
            DAL_User daluser = new DAL_User();
            List<User> lstUsers = null;
            try
            {
                lstUsers = daluser.GetAllUsers();
            }
            catch (Exception ex)
            {

            }
            return Json(lstUsers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Insert_User(User user)
        {

            DAL_User daluser = new DAL_User();
            string resultmsg = string.Empty;
            try
            {
                resultmsg = daluser.Insert_UpdateUser(user);

            }
            catch (Exception ex)
            {

            }
            return Json(resultmsg, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Delete_User(User user)
        {

            DAL_User daluser = new DAL_User();
            string resultmsg = string.Empty;
            try
            {
                resultmsg = daluser.Delete_User(user);

            }
            catch (Exception ex)
            {

            }
            return Json(resultmsg, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Update_User(User user)
        {

            DAL_User daluser = new DAL_User();
            string resultmsg = string.Empty;
            try
            {
                resultmsg = daluser.Insert_UpdateUser(user);

            }
            catch (Exception ex)
            {

            }
            return Json(resultmsg, JsonRequestBehavior.AllowGet);

        }
    }
}