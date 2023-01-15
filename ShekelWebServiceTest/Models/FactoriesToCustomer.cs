using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShekelWebServiceTest.Models
{
    public class FactoriesToCustomer
    {
        [Key, Column(Order = 0)]
        public int groupCode { get; set; }
        [Key, Column(Order = 1)]
        public int factoryCode { get; set; }
        [Key, Column(Order = 2)]
        public string customerId { get; set; }
    }
}