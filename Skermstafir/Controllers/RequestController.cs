using Skermstafir.Models;
using Skermstafir.Repositories;
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
		public ActionResult RequestItem(int requestID)
		{
			RequestModel result = new RequestModel();
			RequestRepository rr = new RequestRepository();
			result = rr.GetRequestByID(0);
			return View(result);
		}
		// Adds a new request.
        public ActionResult AddRequest()
        {
            return View();
        }
	}
}