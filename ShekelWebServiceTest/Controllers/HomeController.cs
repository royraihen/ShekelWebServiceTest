using ShekelWebServiceTest.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShekelWebServiceTest.Controllers
{
    public class HomeController : Controller
    {
        DbExecutor executor;

        public HomeController()
        {
            InitMemebers();
        }

        private void InitMemebers()
        {
            executor = new DbExecutor();
        }

        public ActionResult Index()
        {
            return View();
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

        [HttpPost]
        public ActionResult GetGroupsAndCustomers(int groupCode)
        {
            var data = executor.GetGroupsAndCustomers(groupCode);
            return Json(data);
        }

        [HttpPost]
        public ActionResult AddNewCustomer(string customerId, string customerName, string address, string phone, string groupCode, string factoryCode)
        {
            int group, factory;
            int.TryParse(groupCode,out group);
            int.TryParse(factoryCode,out factory);

            if (!IsCustomerExists(customerId))
            {
                if (VerifyFields(customerId, customerName, address, phone, group, factory))
                {
                    executor.AddCustomer(customerId, customerName, address, phone, group, factory);
                    return Json("OK");
                }
            }

            return Json("BAD");
        }

        private bool IsCustomerExists(string customerId)
        {
            var results = executor.CheckCustomer(customerId);
            if (results.Count() > 0) return true;

            return false;
        }

        private bool VerifyFields(string customerId, string customerName, string address, string phone, int group, int factory)
        {
            if (string.IsNullOrEmpty(customerId)) return false;
            if (string.IsNullOrEmpty(customerName)) return false;
            if (string.IsNullOrEmpty(address)) return false;
            if (string.IsNullOrEmpty(phone)) return false;
            if (group == 0) return false;
            if (factory == 0) return false;

            return true;
        }
    }
}