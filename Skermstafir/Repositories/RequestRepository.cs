﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skermstafir.Models;
using Skermstafir.Interfaces;

namespace Skermstafir.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        // adds new request to database
        public void AddRequest(RequestModel newRequest)
        {
            SkermData db = new SkermData();
            db.Requests.Add(newRequest.request);
            db.SaveChanges();
        }

        //deletes a request with a specific id
        public void DeleteRequest(int id)
        {
            SkermData db = new SkermData();
            Request discardRequest = (from req in db.Requests
                                      where req.IdRequest == id
                                      select req).Single();
                db.Requests.Remove(discardRequest);
        }

        // queries and gets requests starting from index start and ending at index end
        public RequestModelList GetRequestByNewest(int start, int end)
        {
            RequestModelList model = new RequestModelList();
            SkermData db = new SkermData();
            model.modelList = (from req in db.Requests
                               orderby req.DateAdded
                               select req).Skip(start).Take(end - start).ToList();
            return model;
        }

        // queries database and gets most popular requests starting at index start and ending at index end
        public RequestModelList GetByMostPopular(int start, int end)
        {
            RequestModelList model = new RequestModelList();
            SkermData db = new SkermData();
            model.modelList = (from req in db.Requests
                               orderby req.Votes.Count
                               select req).Skip(start).Take(end - start).ToList();
            return model;
        }

        // queries database and gets all requests from a specific user starting at index start and ending at index end both inclusive
        public RequestModelList GetRequestsByUser(String userName)
        {
            RequestModelList model = new RequestModelList();
            SkermData db = new SkermData();
            model.modelList = (from req in db.Requests
                               where req.Username == userName
                               select req).ToList();
            return model;
        }

        // queries and gets a request by id
        public RequestModel GetRequestByID(int id)
        {
            RequestModel model = new RequestModel();
            SkermData db = new SkermData();
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
            SkermData db = new SkermData();
            modelList.modelList = (from req in db.Requests
                                    where req.Language.Name == language
                                    orderby req.IdRequest
                                    select req).Skip(start).Take(end - start).ToList();
            return modelList;
        }

		public RequestModelList GetRequestsByString(String str) {
			RequestModelList model = new RequestModelList();
			SkermData db = new SkermData();
			model.modelList = (from req in db.Requests
							   where req.Name.Contains(str)
							   select req).ToList();
			return model;
		}

		public RequestModelList GetRequestsByYear(int start, int end) {
			RequestModelList model = new RequestModelList();
			SkermData db = new SkermData();
			model.modelList = (from req in db.Requests
							   where req.YearCreated >= start && req.YearCreated <= end
							   select req).ToList();
			return model;
		}

		public RequestModelList GetRequestsByGenre(string genre) {
			RequestModelList model = new RequestModelList();
			model.modelList = new List<Request>();
			SkermData db = new SkermData();
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
    }
}