using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skermstafir.Models
{
    public class RequestModel
    {
        public String name { get; set; }
        public string description { get; set; }
        public int yearCreated { get; set; }
        public DateTime dateAdded { get; set; }
        public String Language { get; set; }
        public List<String> artists { get; set; }
        public int votes { get; set; }
    }
}