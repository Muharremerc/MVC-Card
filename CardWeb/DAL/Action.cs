using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class Action
    {

        private Action()
        { }

        private static Action Clas;
        public static Action getClassEntity()
        {
            if (Clas == null)
                Clas = new Action();

            return Clas;

        }


        public List<Category> getAllCategories()
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                return db.Categories.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Product> getAllProducts()
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                return db.Products.ToList();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<Product> getAllProductsbyCategoryId(int Id)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                List<Product> pList = new List<Product>();
                var p = db.ProductCategories.Include("Category").Include("Product").Where(x => x.CategoryId == Id).ToList();



                foreach (var item in p)
                {

                    pList.Add(new Product
                    {
                        Id = item.Product.Id,
                        Name = item.Product.Name,
                        Price = item.Product.Price,
                        Pricings = item.Product.Pricings,
                        ShopId = item.Product.ShopId
                    }
                    );

                }
                return pList;

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public TicketProduct addProductToTicket(int productId, int ticketId)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                TicketProduct tp = new TicketProduct();
                tp.ProductId = productId;
                tp.TicketId = ticketId;
                db.TicketProducts.Add(tp);
                db.SaveChanges();
                return tp;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public Ticket CreateTicket(string name, string cardId)
        {
            try
            {

                var db = MarketEntities.getDbEntity();
                var card = db.Cards.FirstOrDefault(x => x.CardId == cardId);
                var customerId = db.CustomerCards.FirstOrDefault(x => x.CardId == card.Id);

                if (customerId != null)
                {
                    Ticket t = new Ticket();
                    t.Name = name;
                    t.CustomerId = customerId.Id;
                    db.Tickets.Add(t);
                    db.SaveChanges();
                    return t;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Product> getProductByTicketId(int id)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                var list = db.TicketProducts.Include("Product").Where(x => x.TicketId == id).ToList();
                List<Product> productList = new List<Product>();
                foreach (var item in list)
                {
                    productList.Add(
                        new Product
                        {
                            Id = item.Product.Id,
                            Name = item.Product.Name,
                            Price = item.Product.Price,
                            Pricings = item.Product.Pricings,
                            ShopId = item.Product.ShopId
                        });
                }

                return productList;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public Userr Login(string username, string password)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                var user = db.Userrs.Where(x => x.Username == username).Where(x => x.Password == password).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Product> getProductByUserId(int id)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                var list = db.UserShops.Where(x => x.UserId == id).FirstOrDefault();
                var productList = db.Products.Include("ProductImages.Image").Where(x => x.ShopId == list.ShopId).ToList();


                return productList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string getShopNameByShopId(int id)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                var c = db.Shops.Where(x => x.Id == id).FirstOrDefault();
                if (c != null)
                    return c.Name;
                return "A";
            }
            catch (Exception)
            {

                throw;
            }

        }






        public Product AddNewProduct(string name, int price, int cId, int shopId)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                Product p = new Product();
                p.Name = name;
                p.Price = price;
                p.ShopId = shopId;
                var pId = db.Products.Add(p);
                ProductCategory pc = new ProductCategory();
                pc.ProductId = pId.Id;
                pc.CategoryId = cId;
                db.ProductCategories.Add(pc);
                db.SaveChanges();

                return p;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public UserShop getShopByUserId(int id)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                var s = db.UserShops.Where(x => x.UserId == id).FirstOrDefault();
                return s;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Image addImage(string image)
        {
            var db = MarketEntities.getDbEntity();
            Image i = new Image();
            i.ImageName = image;
            db.Images.Add(i);
            db.SaveChanges();
            return i;
        }

        public ProductImage AddImageProduct(int p, int i)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                ProductImage pi = new ProductImage();
                pi.ImageId = i;
                pi.ProductId = p;
                db.ProductImages.Add(pi);
                db.SaveChanges();
                return pi;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string getImageName(int id)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                var imagename = db.ProductImages.Include("Image").Include("Product").Where(x => x.ProductId == id).FirstOrDefault();


                if (imagename.Image.ImageName == null)
                    return "default.jpg";
                return imagename.Image.ImageName;
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public Category addNewCategory(string name)
        {

            try
            {
                var db = MarketEntities.getDbEntity();
                Category c = new Category
                {
                    Name = name

                };
                db.Categories.Add(c);
                db.SaveChanges();
                return c;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool checkCatgoryName(string name)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                return true;

            }
            catch (Exception)
            {

                throw;
            }


        }

        public string getCustomerByTicketId(int id)
        {

            try
            {
                var db = MarketEntities.getDbEntity();
                var c = db.Tickets.Include("Customer").Where(x => x.Id == id).FirstOrDefault();
                return c.Customer.Name;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Customer AddCustomer(string name, string surname, string username, string password, string email, string phone)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                Customer c = new Customer();
                c.Name = name;
                c.Surname = surname;
                c.Password = phone;
                c.Username = username;
                c.Email = email;
                c.Password = password;
                db.Customers.Add(c);
                db.SaveChanges();
                return c;


            }
            catch (Exception)
            {

                throw;
            }

        }

        public Card addCard(string card)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                Card c = new Card();
                c.IsActive = false;
                c.CardId = card;
               
                db.Cards.Add(c);
                db.SaveChanges();
                return c;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CustomerCard addCustomerCard(int customerId, int cardId)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                CustomerCard cc = new CustomerCard();
                cc.CustomerId = customerId;
                cc.CardId = cardId;
                db.CustomerCards.Add(cc);
                db.SaveChanges();
                return cc;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool DeleteTicketProduct(int id)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                var p = db.TicketProducts.Where(x => x.ProductId == id).ToList();
                foreach (var item in p)
                {
                    db.TicketProducts.Remove(item);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteProductImages(int id)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                var p = db.ProductImages.Where(x => x.ProductId == id).FirstOrDefault();
                db.ProductImages.Remove(p);

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool DeleteProductCategories(int id)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                var p = db.ProductCategories.FirstOrDefault(x => x.ProductId == id);
                db.ProductCategories.Remove(p);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                var p = db.Products.FirstOrDefault(x => x.Id == id);
                DeleteProductCategories(id);
                DeleteProductImages(id);
                DeleteTicketProduct(id);
                db.Products.Remove(p);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool deleteProductFromTicket(int proid, int ticketid)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                var pt = db.TicketProducts.Where(x => x.ProductId == proid && x.TicketId == ticketid).FirstOrDefault();
                db.TicketProducts.Remove(pt);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool AddShopUser(string sname,string name, string surname, string username, string password, string email, string phone)
        {
            try
            {
                var db = MarketEntities.getDbEntity();
                var u = AddUser(name,surname,username,password,email,phone);
                var s = AddShop(sname);
                UserShop us = new UserShop();
                us.ShopId = s.Id;
                us.UserId = u.Id;
                db.UserShops.Add(us);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

         }

        public Userr AddUser(string name,string surname, string username, string password, string email, string phone)
        {

            try
            {
                var db = MarketEntities.getDbEntity();
                Userr u = new Userr
                {
                    Name=name,
                    Email=email,
                    Password=password,
                    Phone=phone,
                    Surname=surname,
                    Username=username
                };
                db.Userrs.Add(u);
                db.SaveChanges();               

                return u;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Shop AddShop(string sname)
        {

            try
            {
                var db = MarketEntities.getDbEntity();
                Shop s = new Shop();
                s.Name = sname;
                db.Shops.Add(s);
                db.SaveChanges();

                return s;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddMoneytoCard(int money, int ticketid)
        {

            var db = MarketEntities.getDbEntity();
            var t = db.Tickets.Where(x => x.Id == ticketid).FirstOrDefault();
            var c = db.CustomerCards.FirstOrDefault(x => x.CardId == t.CustomerId);
            var card = db.Cards.FirstOrDefault(x => x.Id == c.CardId);
            card.Money += money;
            db.SaveChanges();

            return true;

        }

        public int getMoneybyCarId(string carid)
        {
            var db = MarketEntities.getDbEntity();
            var money = db.Cards.FirstOrDefault(x => x.CardId==carid);
            return Convert.ToInt32(money.Money);
        }
    }
}
