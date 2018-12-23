using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace CardWeb.Models
{
    public class IndexViewModel
    {
        public List<ProductShop> P { get; set; }
        public List<Category> C { get; set; }
    }


    public class ProductShop
    {
        public Product P { get; set; }
        public string ShopName { get; set; }
        public string Image { get; set; }

    }
}