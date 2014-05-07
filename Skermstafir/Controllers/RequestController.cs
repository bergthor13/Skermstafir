using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skermstafir.Controllers
{
    public class RequestController : Controller
    {
        //
        // GET: /Request/
		public ActionResult Request(int requestID)
		{
			return View();
		}
		// Adds a new request.
        public ActionResult AddRequest()
        {
            return View();
        }
	}
}