using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoginCheck(string username,string password)
        {

            try
            {
                
                var classEntitiy = DAL.Action.getClassEntity();
                var user = classEntitiy.Login(username, password);

                if (user != null)
                {
                    Session["UserId"] = user.Id;
                    var sId= classEntitiy.getShopByUserId(user.Id);
                    Session["ShopId"] = sId.ShopId;
                    return Json(user.Id);
                    
                }
                return Json(0);

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}