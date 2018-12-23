using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var id = Session["UserId"];
            if (id != null)
            {
                var classEntity = DAL.Action.getClassEntity();
                var productList = classEntity.getProductByUserId(Int32.Parse(id.ToString()));
                List<CardWeb.Models.ProductAndShopName> pm = new List<Models.ProductAndShopName>();
                foreach (var item in productList)
                {
                    foreach (var item2 in item.ProductImages)
                    {
                        pm.Add(new Models.ProductAndShopName
                        {
                            P = item,
                            ShopName = classEntity.getShopNameByShopId(Int32.Parse(item.ShopId.ToString())),
                            Image = item2.Image.ImageName

                        });
                    }

                }


                CardWeb.Models.ProductIndexModel pmodel = new Models.ProductIndexModel();
                pmodel.P = pm;
                pmodel.C = classEntity.getAllCategories();
                return View(pmodel);

            }
            return Redirect("../../Home/Index");
        }


        public ActionResult AddNewProduct(string name,int price,int cId, HttpPostedFileBase f)
        {
            try
            {
                var classEntity = DAL.Action.getClassEntity();
                var sIp = Session["ShopId"];
                var p = classEntity.AddNewProduct(name, price,cId,Int32.Parse(sIp.ToString()));
                string path = Path.Combine(Server.MapPath("~/Image"),
                System.IO.Path.GetFileName(f.FileName));
                f.SaveAs(path);
                Model.Image img = new Model.Image();
                string[] words = f.FileName.Split('\\');
                var count = words.Count();
                var addimage = classEntity.addImage(words[count - 1]);
                var saveImageProduct = classEntity.AddImageProduct(p.Id, addimage.Id);
                return Redirect("/Product/Index");

            }
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult addNewCategory(string name)
        {
            try
            {
                var classEntitiy = DAL.Action.getClassEntity();
                var c = classEntitiy.addNewCategory(name);
                var check = classEntitiy.checkCatgoryName(name);
                return Json(c);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult Delete(int id)
        {
            try
            {
                var classEntitiy = DAL.Action.getClassEntity();
                var p = classEntitiy.Delete(id);
                return Json("true");
            }
            catch (Exception)
            {

                throw;
            }
        }

        

    }
}