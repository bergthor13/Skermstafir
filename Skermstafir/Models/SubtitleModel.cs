using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skermstafir.Models
{
    public class SubtitleModel
    {
        public String name { get; set; }
        public String content { get; set; }
        public int yearCreated { get; set; }
        public DateTime dateCreated { get; set; }
        public String language { get; set; }
        public List<String> artists { get; set; }
        public int votes { get; set; }
        public int downloads { get; set; }

		public SubtitleModel()
		{
			artists = new List<String>();
		}
    }
}