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
		[HttpGet]
		public ActionResult ShowRequest(int? id)
		{
			if (id == null)
			{
				return View("Errors/NoSubFound");
			}

			try
			{
				SkermData db = new SkermData();
				RequestRepository sr = new RequestRepository(db);
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
			SkermData db = new SkermData();
			RequestModel reqModel = new RequestModel();
            RequestRepository reqRepo = new RequestRepository(db);
            SearchRepository searchRepo = new SearchRepository(db);
        
            // Start adding data into the request model to be added into the database.
            //      Get the name from the title box and make it the reqModel's name.
            if(fc["title"] == "")
            {
                reqModel.request.Name = "Ekki skráð.";
            }
            else
            {
                reqModel.request.Name = fc["title"];
            }
            //      Get the description from the description box and make it the reqModel's description.
            if (fc["description"] == "")
            {
                reqModel.request.Description = "Ekki skráð.";
            }
            else
            {
                reqModel.request.Description = fc["description"];
            }

            // Gets the director object specified in the 'director' textbox in the view.
            if (fc["director"] == "")
            {
                reqModel.request.Director = "Ekki skráð.";
            }
            else
            {
                reqModel.request.Director = fc["director"];
            }

			if (fc["actors"] == "")
			{
				reqModel.request.Actors = "Ekki skráð.";
			}
			else
			{
				reqModel.request.Actors = fc["director"];
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
            if (fc["year"] == "")
            {
                reqModel.request.YearCreated = 0;
            }
            else
            {
                reqModel.request.YearCreated = Convert.ToInt32(fc["year"]);
            }

            // Set the date this request was made.
            reqModel.request.DateAdded = DateTime.Now;

            // Set the link of this requirement.
            if (fc["link"] == "")
            {
                reqModel.request.Link = "Ekki skráð.";
            }
            else
            {
                reqModel.request.Link = fc["link"];
            }
            
            
            // Adding the genres
            for (int i = 1; i < 9; i++)
            {
                if (fc["genre" + i.ToString()] == "on")
                {
                    reqModel.request.Genres.Add(searchRepo.GetGenreByID(i));
                    reqModel.genreValue[i - 1] = true;
                }
            }
            
            // Here the request has all the info it needs and we add it to our Request table.
            reqRepo.AddRequest(reqModel);


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
		}

		public ActionResult Search(FormCollection form) {
			SkermData db = new SkermData();
			RequestModelList model = new RequestModelList();
			RequestRepository reqRep = new RequestRepository(db);

			// get by string
			List<Request> stringResult = reqRep.GetRequestsByString(form["searchValue"]).modelList;

			// get by language
			List<Request> langResult = new List<Request>();

			langResult = reqRep.GetRequestByLanguage(form["language"], 0, 5).modelList;

			// get by year
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
			ls.Add(langResult);
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
			SkermData db = new SkermData();
            RequestRepository reqRepo = new RequestRepository(db);
            int idValue = id.Value;
            reqRepo.DeleteRequest(idValue);
            return RedirectToAction("Manage", "Account");
        }

		public ActionResult UpvoteRequest(int reqid)
		{
			string userName = User.Identity.GetUserName();
			string userId = User.Identity.GetUserId();
			SkermData db = new SkermData();
			RequestRepository reqRepo = new RequestRepository(db);
			Vote vote = reqRepo.GetVoteByUserID(userId);
			RequestModel req = reqRepo.GetRequestByID(reqid);
			Request request = req.request;

			// Check for user.
			if (userName == "")
			{
				// User is not logged in.
				var noUser = new { Exists = 3 };
				return Json(noUser, JsonRequestBehavior.AllowGet);
			}
			else if (userName == request.Username)
			{
				var subOwner = new { Exists = 2 };
				return Json(subOwner, JsonRequestBehavior.AllowGet);
			}
			//------------------------------------------------------
			// Check for vote.
			if (reqRepo.VoteContainsRequest(vote, request))
			{
				reqRepo.RemoveVoteFromRequest(vote, request);
				var existsYes = new { Exists = 1 };
				return Json(existsYes, JsonRequestBehavior.AllowGet);
			}
			else
			{
				reqRepo.AddVoteToRequest(vote, request);
				var existsNo = new { Exists = 0 };
				return Json(existsNo, JsonRequestBehavior.AllowGet);
			}
		}

	}
}