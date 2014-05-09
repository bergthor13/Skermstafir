<<<<<<< HEAD
﻿using Skermstafir.Models;
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
        public ActionResult AddRequest()
        {
            return View();
        }
	}
=======
﻿using Skermstafir.Models;
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
			return View();
		}
		// Adds a new request.
        public ActionResult AddRequest()
        {
            return View();
        }
	}
>>>>>>> 4be52bc1ef7c2d7fdb466599853d340e2f213a40
}