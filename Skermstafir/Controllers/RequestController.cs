using Skermstafir.Exceptions;
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
		public ActionResult ShowRequest(int? id)
		{
			if (id == null)
			{
				return View("Errors/NoSubFound");
			}

			try
			{
				RequestRepository sr = new RequestRepository();
				int idValue = id.Value;
				RequestModel result = sr.GetRequestByID(idValue);
				FillModel(result);
				return View(result);
			}
			catch (NoRequestFoundException)
			{
				return View("Errors/NoSubFound");
			}
		}
		// Adds a new request.
		public ActionResult CreateRequest()
		{
			RequestModel model = new RequestModel();
			return View(model);
		}

		public void FillModel(RequestModel rm)
		{
			foreach (var item in rm.request.Genres)
			{
				for (int i = 0; i < 8; i++)
				{
					if (item.IdGenre == i + 1)
					{
						rm.genreValue[i] = true;
					}
				}
			}

			foreach (var art in rm.request.Actors)
			{
				if (art != rm.request.Actors.Last())
				{
					rm.actorsForView += art.Name + ", ";
				}
				else
				{
					rm.actorsForView += art.Name;
				}
			}
		}
	}
}