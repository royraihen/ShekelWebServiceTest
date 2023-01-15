using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShekelWebServiceTest.Models
{
    public class Groups
    {
        [Key, Column(Order = 0)]
        public int groupCode { get; set; }
        public string groupName { get; set; }
    }
}