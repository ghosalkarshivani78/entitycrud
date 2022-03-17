using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEntityframe.Models
{
    public class person
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public int number { get; set; }
        public string city { get; set; }
        public List<person> user = new List<person>();
    }
}