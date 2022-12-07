using GridCrudOperation.dbo_connt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GridCrudOperation.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            testEntities1 entities = new testEntities1();
            List<Customer> customers = entities.Customers.ToList();

            
            customers.Insert(0, new Customer());
            return View(customers.ToList());
        }

        [HttpPost]
        public JsonResult InsertCustomer(Customer customer)
        {
            using (testEntities1 entities = new testEntities1())
            {
                entities.Customers.Add(customer);
                entities.SaveChanges();
            }

            return Json(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer obj)
        {
            using (testEntities1 entities = new testEntities1())
            {
                Customer customer = (from c in entities.Customers
                                            where c.Id == obj.Id
                                            select c).FirstOrDefault();
                customer.Name = customer.Name;
                customer.Country = customer.Country;
                entities.SaveChanges();

            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int Id)
        {
            using (testEntities1 entities = new testEntities1())
            {
                Customer customer = (from c in entities.Customers
                                     where c.Id == Id
                                     select c).FirstOrDefault();
                entities.Customers.Remove(customer);
                entities.SaveChanges();
            }
            return new EmptyResult();
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
    }
}