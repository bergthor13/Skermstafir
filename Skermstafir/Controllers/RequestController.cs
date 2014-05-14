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
        [HttpPost]
		public ActionResult CreateRequest(FormCollection fc)
		{
			RequestModel model = new RequestModel();
            RequestRepository rr = new RequestRepository();
            SearchRepository sr = new SearchRepository();
        
            model.request.Name = fc["title"];
            model.request.Director.Name = fc["director"];
            model.request.Description = fc["description"];

            if (User.Identity.Name != null)
            {
                model.request.Username = User.Identity.Name;
            }
            else
            {
                model.request.Username = "Anonymous";
            }

            if (fc["language"] == "Islenska")
            {
                model.request.LanguageId = 1;
            }
            else
            {
                model.request.LanguageId = 2;
            }

            int year = Convert.ToInt32(fc["year"]);
            model.request.YearCreated = year;

            model.request.DateAdded = DateTime.Now;
            model.request.Link = fc["link"];

            

            string actors = fc["actors"];
            String[] actorers = actors.Split(',');
            for (int i = 0; i < actorers.Length; i++)
            {
                if (i > 0)
                {
                    actorers[i] = actorers[i].Substring(1);
                }
            }
            rr.AddRequest(model);
            SkermData db = new SkermData();

            foreach (var item in actorers)
            {
                Actor temp = new Actor();
                if(sr.GetActorByName(item) == null)
                {
                    temp.Name = item;
                    db.Actors.Add(temp);
                    db.SaveChanges();
                }
                else
                {
                    temp = sr.GetActorByName(item);
                }
                temp.Requests.Add(model.request);
                model.request.Actors.Add(temp);
            }


            for (int i = 1; i < 9; i++)
            {
                if (fc["genre" + i.ToString()] == "on")
                {
                    model.request.Genres.Add(sr.GetGenreByID(i));
                }
            }

            return RedirectToAction("ShowRequest", new { id = model.request.IdRequest });
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
			if (form["Þættir"] == "on") {
				genreResult = genreResult.Union(reqRep.GetRequestsByGenre("Þættir").modelList).ToList();
			}
			if (form["Barnaefni"] == "on") {
				genreResult = genreResult.Union(reqRep.GetRequestsByGenre("Barnaefni").modelList).ToList();
			}
			if (form["Heimildir"] == "on") {
				genreResult = genreResult.Union(reqRep.GetRequestsByGenre("Heimildir").modelList).ToList();
			}
			if (form["Gaman"] == "on") {
				genreResult = genreResult.Union(reqRep.GetRequestsByGenre("Gaman").modelList).ToList();
			}
			if (form["Spenna"] == "on") {
				genreResult = genreResult.Union(reqRep.GetRequestsByGenre("Spenna").modelList).ToList();
			}
			if (form["Drama"] == "on") {
				genreResult = genreResult.Union(reqRep.GetRequestsByGenre("Drama").modelList).ToList();
			}
			if (form["Ævintýri"] == "on") {
				genreResult = genreResult.Union(reqRep.GetRequestsByGenre("Ævintýri").modelList).ToList();
			}
			List<List<Request>> ls = new List<List<Request>>();
			ls.Add(stringResult);
			ls.Add(yearResult);
			ls.Add(genreResult);
			bool first = true;
			// get intersection
			foreach (var list in ls) { 
				if (list.Count != 0) {
					if (first) {
						model.modelList = list;
						first = false;
					} else {
						model.modelList = model.modelList.Intersect(list).ToList();
					}
				}
			}
			// add union for edge results
			//foreach (var list in ls) {
			//	model.modelList = model.modelList.Union(list).ToList();
			//}
			return View(model);
		}
        //Delete request
        public ActionResult DeleteRequest(int? id)
        {
            
            RequestRepository reqRepo = new RequestRepository();
            int idValue = id.Value;
            reqRepo.DeleteRequest(idValue);
            return RedirectToAction("Manage", "Account");
        }
	}
}