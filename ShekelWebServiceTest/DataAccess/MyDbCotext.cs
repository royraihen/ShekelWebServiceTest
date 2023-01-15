using ShekelWebServiceTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShekelWebServiceTest.DataAccess
{
    public class MyDbCotext : DbContext
    {
        public MyDbCotext() : base("name=DefaultConnection") { }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Factories> Factories { get; set; }
        public DbSet<FactoriesToCustomer> FactoriesToCustomer { get; set; }

    }
}