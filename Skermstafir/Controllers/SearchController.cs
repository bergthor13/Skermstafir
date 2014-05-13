using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Skermstafir.Models;
using Skermstafir.Repositories;

namespace Skermstafir.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
		// FormData PARAMETER
        public ActionResult Search(FormCollection form)
        {
			// SETUP
            SubtitleModelList result = new SubtitleModelList();
			result.modelList = new List<Subtitle>();
  			SearchRepository sc = new SearchRepository();
			// search by string
			List<Subtitle> stringResult = new List<Subtitle>();
			if (form["SearchValue"] != "") {
				stringResult = sc.GetSubtitleByString(form["SearchValue"]).modelList;
			}

			//Search by creation year
			int start, end;
			if (form["StartYear"] != "") {
				start = Convert.ToInt32(form["StartYear"]);
			} else {
				start = 0;
			}
			if (form["EndYear"] != "") {
				end = Convert.ToInt32(form["EndYear"]);
			} else {
				end = 0;
			}
			List<Subtitle> yearResult = sc.GetSubtitleByCreationDate(start, end, 0, 10).modelList;

			// search by genre
			List<Subtitle> genreResult = new List<Subtitle>();
			if (form["Kvikmyndir"] == "on") {
				genreResult = genreResult.Union(sc.GetSubtitleByGenre("Kvikmyndir").modelList).ToList();
			}
			if (form["Þættir"] == "on") {
				genreResult = genreResult.Union(sc.GetSubtitleByGenre("Þættir").modelList).ToList();
			}
			if (form["Barnaefni"] == "on") {
				genreResult = genreResult.Union(sc.GetSubtitleByGenre("Barnaefni").modelList).ToList();
			}
			if (form["Heimildir"] == "on") {
				genreResult = genreResult.Union(sc.GetSubtitleByGenre("Heimildir").modelList).ToList();
			}
			if (form["Gaman"] == "on") {
				genreResult = genreResult.Union(sc.GetSubtitleByGenre("Gaman").modelList).ToList();
			}
			if (form["Spenna"] == "on") {
				genreResult = genreResult.Union(sc.GetSubtitleByGenre("Spenna").modelList).ToList();
			}
			if (form["Drama"] == "on") {
				genreResult = genreResult.Union(sc.GetSubtitleByGenre("Drama").modelList).ToList();
			}
			if (form["Ævintýri"] == "on") {
				genreResult = genreResult.Union(sc.GetSubtitleByGenre("Ævintýri").modelList).ToList();
			}

			// setup lists to merge results
			List<List<Subtitle>> lists = new List<List<Subtitle>>();
			lists.Add(stringResult);
			lists.Add(yearResult);
			lists.Add(genreResult);
			bool first = true;
			// get intersection of all lists
			foreach (var ls in lists) {
				if (ls.Count != 0) {
					if (first) {
						result.modelList = ls;
						first = false;
					} else {
						result.modelList = result.modelList.Intersect(ls).ToList();
					}
				}
			}
			// canceled becouse it made results confusing
			// get the rest of the results
			//foreach (var item in lists) {
			//	result.modelList = result.modelList.Union(item).ToList();
			//}
			return View(result);
        }
	}
}
