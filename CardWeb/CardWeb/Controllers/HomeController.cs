using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using CardWeb.Models;

namespace CardWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductIndexModel model = new ProductIndexModel();

            var classEntity = DAL.Action.getClassEntity();
            var category = classEntity.getAllCategories();
            //var product = classEntity.getAllProducts();

            //List<CardWeb.Models.ProductAndShopName> ps = new List<ProductAndShopName>();

            //foreach (var item in product)
            //{
            //    ps.Add(new ProductAndShopName
            //    {
            //        P=item,
            //        ShopName=classEntity.getShopNameByShopId(Int32.Parse(item.ShopId.ToString()))

            //    });
            //}




            //model.C = category;
            //model.P = ps;

            return View(category);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ProductPView(int id)
        {
            var classEntity = DAL.Action.getClassEntity();
            
            if (id ==0)
            {
                var product = classEntity.getAllProducts();
                List<CardWeb.Models.ProductAndShopName> ps = new List<ProductAndShopName>();

                foreach (var item in product)
                {
                    ps.Add(new ProductAndShopName
                    {
                        P = item,
                        ShopName = classEntity.getShopNameByShopId(Int32.Parse(item.ShopId.ToString())),
                        Image = classEntity.getImageName(item.Id)
                        
                    });
                }
                return PartialView("_ProductPView", ps);
            }
            else
            {
                var product = classEntity.getAllProductsbyCategoryId(id);
                List<CardWeb.Models.ProductAndShopName> ps = new List<ProductAndShopName>();

                foreach (var item in product)
                {
                    ps.Add(new ProductAndShopName
                    {
                        P = item,
                        ShopName = classEntity.getShopNameByShopId(Int32.Parse(item.ShopId.ToString())),
                        Image = classEntity.getImageName(item.Id)

                    });
                }
                return PartialView("_ProductPView", ps);

            }

        }
        public JsonResult AddToTicket(int id)
        {
            try
            {
                var classEntity = DAL.Action.getClassEntity();
                var ticketId = Session["Ticket"] as Model.Ticket;
                if(ticketId!= null)
                { 
                var ProductTicket = classEntity.addProductToTicket(id, ticketId.Id);
                    return Json("True");
                }
                return Json("False");
                
            }
            catch (Exception)
            {

                throw;
            }                     

        }
        
        public JsonResult CreateTicket(string name,string cardId)
        {
            try
            {if(name!=null && cardId!=null)
                {
                    
                    var classEntity = DAL.Action.getClassEntity();
                    var ticket = classEntity.CreateTicket(name,cardId);
                    if(ticket!=null)
                    {
                        Session["Ticket"] = ticket;
                        return Json(ticket);
                    }
                    
                }
                return Json(null);

            }
            catch (Exception)
            {

                throw;
            }

        }
        public ActionResult getCardMoney(string c)
        {

            try
            {
                var classEntity = DAL.Action.getClassEntity();
                int m = classEntity.getMoneybyCarId(c);
                return PartialView("_CardMoneyView", m);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult getProductByTicketId()
        {
            try
            {
                var classEntity = DAL.Action.getClassEntity();
                var ticketId = Session["Ticket"] as Model.Ticket;
                if (ticketId != null)
                {
                    var product = classEntity.getProductByTicketId(ticketId.Id);
                    CardWeb.Models.ProductIndexFinishModel pfs = new ProductIndexFinishModel();
                    List<CardWeb.Models.ProductAndShopName> ps = new List<ProductAndShopName>();
                    foreach (var item in product)
                    {
                        ps.Add(new ProductAndShopName
                        {
                            P = item,
                            ShopName = classEntity.getShopNameByShopId(Int32.Parse(item.ShopId.ToString())),
                            Image = classEntity.getImageName(item.Id)
                        });
                    }
                    pfs.P = ps;
                    pfs.TicketName = ticketId.Name;
                    pfs.TicketCustomer = classEntity.getCustomerByTicketId(ticketId.Id);
                    return PartialView("_ProductSellView", pfs);
                }
                
                return PartialView("False");
            }
            catch (Exception)
            {

                throw;
            }


        }
        public JsonResult Finish()
        {
            try
            {
                var m = 0;
                var classEntity = DAL.Action.getClassEntity();
                var t = Session["Ticket"] as Model.Ticket;
                var product = classEntity.getProductByTicketId(t.Id);
                foreach (var item in product)
                {
                    m += Convert.ToInt32(item.Price);
                }
                var c = classEntity.AddMoneytoCard(m/5, t.Id);

                
                Session["Ticket"] = null;
                return Json(true);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public JsonResult DeleteProductFromTicket(int id)
        {
            try
            {
                var classEntity = DAL.Action.getClassEntity();
                var ticketId = Session["Ticket"] as Model.Ticket;
                var deletep = classEntity.deleteProductFromTicket(id, ticketId.Id);
                return Json("True");
            }
            catch (Exception)
            {

                throw;
            }

        }

    }



}