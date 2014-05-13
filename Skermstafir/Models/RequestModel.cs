using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skermstafir.Models
{
    public class RequestModel
    {
        public Request request { get; set; }
        public int votes { get; set; }

		public bool[] genreValue = new bool[8];
		public string actorsForView;

        public RequestModel()
		{
			request = new Request();
            request.Director = new Director();
            request.Language = new Language();
		}
	}
}
