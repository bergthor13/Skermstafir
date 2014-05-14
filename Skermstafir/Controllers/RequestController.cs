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
			RequestModel reqModel = new RequestModel();
            RequestRepository reqRepo = new RequestRepository();
            SearchRepository searchRepo = new SearchRepository();
        
            // Start adding data into the request model to be added into the database.
            //      Get the name from the title box and make it the reqModel's name.
            reqModel.request.Name = fc["title"];
            //      Get the description from the description box and make it the reqModel's description.
            reqModel.request.Description = fc["description"];

            // Gets the director object specified in the 'director' textbox in the view.
            string directorName = fc["director"];
            Director director = searchRepo.GetDirectorByName(directorName);
            // If the director is not found, we create a new director with that name.
            if (director == null)
            {
                Director newDir = new Director();
                newDir.Name = directorName;
                searchRepo.AddDirector(newDir);
                reqModel.request.DirectorId = newDir.IdDirector;
                // Else we change the director of the request.
            }
            else
            {
                reqModel.request.DirectorId = director.IdDirector;
            }

            // Set the username of the creator to either "Anonymous" (if not authenticated)
            // or (if authenticated) to the user's username.
            if (User.Identity.Name != "")
            {
                reqModel.request.Username = User.Identity.Name;
            }
            else
            {
                reqModel.request.Username = "Anonymous";
            }

            // Find and set which language the request has.
            if (fc["language"] == "Islenska")
            {
                reqModel.request.LanguageId = 1;
            }
            else
            {
                reqModel.request.LanguageId = 2;
            }

            // Set the publish date of the film/show.
            int year = Convert.ToInt32(fc["year"]);
            reqModel.request.YearCreated = year;

            // Set the date this request was made.
            reqModel.request.DateAdded = DateTime.Now;

            // Set the link of this requirement.
            reqModel.request.Link = fc["link"];

            // Get the actors, written into the 'actors' field, and connect them to the request.
            string actors = fc["actors"];
            String[] actorers = actors.Split(',');
            for (int i = 0; i < actorers.Length; i++)
            {
                if (i > 0)
                {
                    actorers[i] = actorers[i].Substring(1);
                }
                // Check if he already exists in database.
                Actor actorToCheck = searchRepo.GetActorByName(actorers[i]);
                // if he doesn't, we add him and connect him to the request.
                if (actorToCheck == null)
                {
                    Actor newActor = new Actor();
                    newActor.Name = actorers[i];
                    searchRepo.AddActor(newActor);
                    reqModel.request.Actors.Add(newActor);
                }
                else
                // Else we just connect him to the request.
                {
                    reqModel.request.Actors.Add(actorToCheck);
                }
            }

            // Here the request has all the info it needs and we add it to our Request table.
            reqRepo.AddRequest(reqModel);

            /*
            // Adding the genres
            for (int i = 1; i < 9; i++)
            {
                if (fc["genre" + i.ToString()] == "on")
                {
                    reqModel.request.Genres.Add(searchRepo.GetGenreByID(i));
                }
            }*/

            return RedirectToAction("ShowRequest", new { id = reqModel.request.IdRequest });
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