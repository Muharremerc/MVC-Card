using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardWeb.Controllers
{
    public class CreateController : Controller
    {
        // GET: Create
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shop()
        {
            return View();
        }

        public JsonResult AddCustomer(string card,string name, string surname, string username, string password, string email, string phone)
        {

            try
            {
                var classEntity = DAL.Action.getClassEntity();
                var c = classEntity.AddCustomer(name, surname, username, password, email, phone);
                var ca = classEntity.addCard(card);
                var cardCustomer = classEntity.addCustomerCard(c.Id, ca.Id);
                return Json(true);               

            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult AddShop(string sname, string name, string surname, string username, string password, string email, string phone)
        {

            try
            {
                var classEntity = DAL.Action.getClassEntity();
                var c = classEntity.AddShopUser(sname,name, surname, username, password, email, phone);
                return Json(true);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}