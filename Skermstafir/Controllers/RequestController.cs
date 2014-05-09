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
		public ActionResult ShowRequest(int? requestID)
		{
			RequestRepository rr = new RequestRepository();
			RequestModel result = rr.GetRequestByID(5);
			return View(result);
		}
		// Adds a new request.
        public ActionResult CreateRequest()
        {
            RequestModel newRequest = new RequestModel();
            return View(newRequest);
        }
	}
}