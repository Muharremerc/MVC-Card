using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardWeb.Models
{
    public class ProductIndexModel
    {
        public List<ProductAndShopName> P { get; set; }
        public List<Model.Category> C { get; set; }
    }

    public class ProductIndexFinishModel
    {
        public List<ProductAndShopName> P { get; set; }
        public string TicketName { get; set; }
        public string TicketCustomer { get; set; }
        public string TicketCustomerCardId { get; set; }
    }

    public class ProductAndShopName
    {
        public Model.Product P { get; set; }
        public string ShopName { get; set; }
        public string Image { get; set; }

    }
}