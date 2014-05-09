using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skermstafir.Models
{
    public class RequestModel
    {
        public Request request { get; set; }
        public List<Artist> artists { get; set;}
        public int votes { get; set; }

        public RequestModel()
        {
            artists = new List<Artist>();
        }
	}
}