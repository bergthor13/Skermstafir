using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skermstafir.Models;
using Skermstafir.Interfaces;
using Skermstafir.Exceptions;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace Skermstafir.Repositories {
	public class SearchRepository : ISearchRepository {
		public SkermData db = new SkermData();
		// queries database to get the newest starting from start and ending at end bot inclusive
		public SubtitleModelList GetSubtitleByNewest(int start, int end) {
			SubtitleModelList model = new SubtitleModelList();
			model.modelList = (from sub in db.Subtitles
							   orderby sub.DateAdded
							   select sub).Skip(start).Take(end - start).ToList();
			return model;
		}

		public SubtitleModelList GetSubtitleByString(String str) {
			SubtitleModelList model = new SubtitleModelList();
			model.modelList = (from sub in db.Subtitles
							   where sub.Name.Contains(str)
							   select sub).ToList();
			return model;
		}

		// queries database to get a list of most popular subtitles starting at index start and ending at index end both inclusive
		public SubtitleModelList GetSubtitleByMostPopular(int start, int end) {
			SubtitleModelList model = new SubtitleModelList();
			model.modelList = (from sub in db.Subtitles
							   orderby sub.Votes.Count descending
							   select sub).Skip(start).Take(end - start).ToList();
			return model;
		}

		// queries database and gets subtitles from a specific user starting at index start and ending at index end both inclusice
		public SubtitleModelList GetSubtitlesByUserID(String userID) {
			SubtitleModelList model = new SubtitleModelList();
			model.modelList = (from sub in db.Subtitles
							   where sub.Username == userID
							   select sub).ToList();
			return model;
		}


		// query database to get a specific subtitle
		public SubtitleModel GetSubtitleByID(int id) {
			SubtitleModel model = new SubtitleModel();
			model.subtitle = (from sub in db.Subtitles
							  where sub.IdSubtitle == id
							  select sub).SingleOrDefault();

			if (model.subtitle == null) {
				throw new NoSubtitleFoundException();
			}

			return model;
		}

		// query database to get subtitles by language starting at index start and ending at index end both inclusive
		public SubtitleModelList GetSubtitleByLanguage(string language, int start, int end) {
			SubtitleModelList model = new SubtitleModelList();
			model.modelList = (from sub in db.Subtitles
							   where sub.Language.Name == language
							   select sub).Skip(start).Take(end - start).ToList();
			return model;
		}

		// query database to get subtitles by creation year starting from start and ending with end both inclusive
		public SubtitleModelList GetSubtitleByCreationDate(int startYear, int endYear, int start, int end) {
			SubtitleModelList model = new SubtitleModelList();
			model.modelList = (from sub in db.Subtitles
							   where sub.YearCreated >= startYear && sub.YearCreated <= endYear
							   orderby sub.YearCreated
							   select sub).Skip(start).Take(end - start).ToList();
			return model;
		}


		// Query database and get a subtitles of a specified genre
		public SubtitleModelList GetSubtitleByGenre(String genreName) {
			SubtitleModelList model = new SubtitleModelList();
			model.modelList = new List<Subtitle>();
			List<Subtitle> ls = (from sub in db.Subtitles
								 select sub).ToList();

			for (int i = 0; i < ls.Count; i++) {
				foreach (var genre in ls[i].Genres) {
					if (genre.Name == genreName) {
						model.modelList.Add(ls[i]);
					}
				}
			}
			return model;
		}

		// Add Director to database
		public void AddDirector(Director dir) {
			db.Directors.Add(dir);
			db.SaveChanges();
		}

        // Add Actor to database
        public void AddActor(Actor act)
        {
            db.Actors.Add(act);
            db.SaveChanges();
        }

		// query database and get a genre by id
		public Genre GetGenreByID(int id) {
			Genre gen = (from item in db.Genres
						 where item.IdGenre == id
                         select item).FirstOrDefault();
			return gen;
		}

		// Query database and get an Actor by his id
        public Actor GetActorByID(int id)
        {
            Actor act = (from item in db.Actors
                         where item.IdActor == id
                         select item).FirstOrDefault();
            return act;
        }

		//Query database and get an Actor by his name
        public Actor GetActorByName(string name)
        {
            Actor act = (from item in db.Actors
                         where item.Name == name
                         select item).FirstOrDefault();
            return act;
        }

		// query database and get a director by name
        public Director GetDirectorByName(string name)
        {
            Director dir = (from item in db.Directors
                            where item.Name == name
                            select item).FirstOrDefault();
            return dir;
        }

		// Query database and get a language by its name
        public Language GetLanguageByName(string name)
        {
            Language lang = (from item in db.Languages
                             where item.Name == name
                             select item).FirstOrDefault();
            return lang;
        }

		public Vote GetVoteByUserID(string userId)
		{
			Vote vote = (from item in db.Votes
						 where item.UserId == userId
						 select item).SingleOrDefault();
			return vote;
		}

		public bool VoteContainsSubtitle(Vote vote, Subtitle subtitle)
		{
			if (subtitle.Votes.Contains(vote))
			{
				return true;
			}
			return false;
		}

		public void AddVoteToSubtite(Vote vote, Subtitle subtitle)
		{

			vote.Subtitles.Add(subtitle);
			subtitle.Votes.Add(vote);
			db.SaveChanges();
		}
	}
}