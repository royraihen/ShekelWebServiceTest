using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShekelWebServiceTest.Models
{
    public class Customers
    {
        [Key, Column(Order = 0)]
        public string customerId { get; set; }
        [Column(Order = 1)]
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}