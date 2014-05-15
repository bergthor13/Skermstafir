using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skermstafir.Models;
using Skermstafir.Interfaces;

namespace Skermstafir.Repositories
{
    public class RequestRepository : IRequestRepository
    {
		SkermData db = new SkermData();

		public RequestRepository(SkermData connection) {
			db = connection;
		}
        // adds new request to database
        public void AddRequest(RequestModel newRequest)
        {
            db.Requests.Add(newRequest.request);
            db.SaveChanges();
        }

        //deletes a request with a specific id
        public void DeleteRequest(int id)
        {
            Request discardRequest = (from req in db.Requests
                                      where req.IdRequest == id
                                      select req).Single();
            db.Requests.Remove(discardRequest);
            db.SaveChanges();
        }

        // queries and gets requests starting from index start and ending at index end
        public RequestModelList GetRequestByNewest(int start, int end)
        {
            RequestModelList model = new RequestModelList();
			model.modelList = (from req in db.Requests
							   orderby req.DateAdded descending
							   select req).Skip(start).Take(end - start).ToList();
            return model;
        }

		public RequestModelList GetRequestByOldest(int start, int end)
		{
			RequestModelList model = new RequestModelList();
			model.modelList = (from req in db.Requests
							   orderby req.DateAdded ascending
							   select req).Skip(start).Take(end - start).ToList();
			return model;
		}

        // queries database and gets most popular requests starting at index start and ending at index end
        public RequestModelList GetByMostPopular(int start, int end)
        {
            RequestModelList model = new RequestModelList();
            model.modelList = (from req in db.Requests
                               orderby req.Votes.Count descending
                               select req).Skip(start).Take(end - start).ToList();
            return model;
        }

        // queries database and gets all requests from a specific user starting at index start and ending at index end both inclusive
        public RequestModelList GetRequestsByUser(String userName)
        {
            RequestModelList model = new RequestModelList();
            model.modelList = (from req in db.Requests
                               where req.Username == userName
                               select req).ToList();
            return model;
        }

        // queries and gets a request by id
        public RequestModel GetRequestByID(int id)
        {
            RequestModel model = new RequestModel();
            model.request = (from req in db.Requests
                                where req.IdRequest == id
                                select req).Single();

            if (model.request == null)
            {
                throw new Exception();
            }

            return model;
        }
        // queries database and gets request in language starting at index start and ending at index end both inclusive
        public RequestModelList GetRequestByLanguage(String language, int start, int end)
        {
            RequestModelList modelList = new RequestModelList();
            modelList.modelList = (from req in db.Requests
                                    where req.Language.Name == language
                                    orderby req.IdRequest
                                    select req).Skip(start).Take(end - start).ToList();
            return modelList;
        }

		public RequestModelList GetRequestsByString(String str) {
			RequestModelList model = new RequestModelList();
			model.modelList = (from req in db.Requests
							   where req.Name.Contains(str)
							   select req).ToList();
			return model;
		}

		public RequestModelList GetRequestsByYear(int start, int end) {
			RequestModelList model = new RequestModelList();
			model.modelList = (from req in db.Requests
							   where req.YearCreated >= start && req.YearCreated <= end
							   select req).ToList();
			return model;
		}

		public RequestModelList GetRequestsByGenre(string genre) {
			RequestModelList model = new RequestModelList();
			model.modelList = new List<Request>();
			List<Request> ls = (from req in db.Requests
								select req).ToList();
			for (int i = 0; i < ls.Count; i++) {
				foreach (var item in ls[i].Genres) {
					if (item.Name == genre) {
						model.modelList.Add(ls[i]);
					}
				}
			}
			return model;
		}

		public bool VoteContainsRequest(Vote vote, Request request)
		{
			return request.Votes.Contains(vote);
		}

		public void AddVoteToRequest(Vote vote, Request request)
		{
			vote.Requests.Add(request);
			request.Votes.Add(vote);
			db.SaveChanges();
		}

		public void RemoveVoteFromRequest(Vote vote, Request request)
		{
			vote.Requests.Remove(request);
			request.Votes.Remove(vote);
			db.SaveChanges();
		}

		public Vote GetVoteByUserID(string userId)
		{
			Vote vote = (from item in db.Votes
						 where item.UserId == userId
						 select item).SingleOrDefault();
			return vote;
		}
	}
}