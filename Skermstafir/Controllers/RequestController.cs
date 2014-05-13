using Skermstafir.Exceptions;
using Skermstafir.Models;
using Skermstafir.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
        [HttpPost]
		public ActionResult CreateRequest(FormCollection fc)
		{
			RequestModel model = new RequestModel();
            RequestRepository rr = new RequestRepository();
        
            model.request.Name = fc["title"];
            model.request.Language.Name = fc["language"];
            model.request.Director.Name = fc["director"];

            if(User.Identity != null)
            {
                model.request.Username = User.Identity.GetUserName();
            }
            else
            {
                model.request.Username = "Anonymous";
            }

            model.request.Description = fc["description"];

            int year = Convert.ToInt32(fc["year"]);
            model.request.YearCreated = year;

            model.request.DateAdded = DateTime.Now;
            model.request.Link = fc["link"];

            string actors = fc["actors"];
            String[] actorers = actors.Split(',');

            foreach (var item in actorers)
            {
                Actor temp = new Actor();
                temp.Name = item;
                model.request.Actors.Add(temp);
            }

            for (int i = 0; i < 8; i++)
            {
                if (fc["genre" + i.ToString()] == "on")
                {
                    Genre temp = new Genre();
                    model.request.Genres.Add(temp);
                }
            }

            if (fc["languages"] == "Íslenska")
            {
                model.request.Language.Name = "Íslenska";
            }
            else if (fc["languages"] == "Enska")
            {
                model.request.Language.Name = "Enska";
            }

            rr.AddRequest(model);

            return this.RedirectToAction("ShowRequest", new { id = model.request.IdRequest });
		}

        [HttpGet]
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

		public ActionResult Search(FormCollection form) {
			RequestModelList model = new RequestModelList();
			RequestRepository reqRep = new RequestRepository();
			List<Request> stringResult = reqRep.GetRequestsByString(form["searchValue"]).modelList;
			int start, end;
			if (form["startYear"] != "") {
				start = Convert.ToInt32(form["startYear"]);
			} else {
				start = 0;
			}
			if (form["endYear"] != "") {
				end = Convert.ToInt32(form["endYear"]);
			} else {
				end = 0;
			}
			List<Request> yearResult = reqRep.GetRequestsByYear(start, end).modelList;
			List<Request> genreResult = new List<Request>();
			if (form["Kvikmyndir"] == "on") {
				genreResult = genreResult.Union(reqRep.GetRequestsByGenre("Kvikmyndir").modelList).ToList();
			}
			model.modelList = yearResult;
			return View(model);
		}
        //Delete request
        public ActionResult DeleteRequest(int? id)
        {
            RequestModel reqModel = new RequestModel();
            RequestRepository reqRepo = new RequestRepository();
            int idValue = id.Value;
            reqModel = reqRepo.GetRequestByID(idValue);
            int idToDelete = reqModel.request.IdRequest;
            DeleteRequest(idToDelete);
            return RedirectToAction("Manage");
        }
	}
}