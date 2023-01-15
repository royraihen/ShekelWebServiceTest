using ShekelWebServiceTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace ShekelWebServiceTest.DataAccess
{
    public class DbExecutor
    {
        public IEnumerable<object> GetGroupsAndCustomers(int groupCode)
        {
            using (var db = new MyDbCotext())
            {
                var data = from g in db.Groups
                           join fc in db.FactoriesToCustomer on g.groupCode equals fc.groupCode
                           join c in db.Customers on fc.customerId equals c.customerId
                           where g.groupCode == groupCode
                           select new { g.groupCode, g.groupName, c.customerId, c.name };
                return data.ToList();
            }
        }

        public IEnumerable<object> CheckCustomer(string customerId)
        {
            using(var db = new MyDbCotext())
            {
                var data = from c in db.Customers
                           where c.customerId == customerId
                           select new { c.customerId, c.name };
                return data.ToList();
            }
        }

        public void AddCustomer(string customerId, string name, string address, string phone, int groupCode, int factoryCode)
        {
            using (var db = new MyDbCotext())
            {
                var newCustomer = new Customers()
                {
                    customerId = customerId,
                    name = name,
                    address = address,
                    phone = phone
                };
                var factoriesToCustomer = new FactoriesToCustomer()
                {
                    groupCode = groupCode,
                    factoryCode = factoryCode,
                    customerId = customerId
                };
                try
                {
                    db.Customers.Add(newCustomer);
                    db.FactoriesToCustomer.Add(factoriesToCustomer);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}