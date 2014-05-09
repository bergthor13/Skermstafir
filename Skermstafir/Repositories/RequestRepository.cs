using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skermstafir.Models;

namespace Skermstafir.Repositories
{
    public class RequestRepository
    {
        // adds new request to database
        public void AddRequest(RequestModel newRequest)
        {
            using(SkermData db = new SkermData())
            {
                db.Requests.Add(newRequest.request);
                db.SaveChanges();
            }
        }

        //deletes a request with a specific id
        public void DeleteRequest(int id)
        {
            using(SkermData db = new SkermData())
            {
                Request discardRequest = (from req in db.Requests
                                          where req.IdRequest == id
                                          select req).Single();
                db.Requests.Remove(discardRequest);
            }
        }

        // queries and gets requests starting from index start and ending at index end
        public RequestModelList GetRequestByNewest(int start, int end)
        {
            RequestModelList model = new RequestModelList();
            using (SkermData db = new SkermData())
            {
                model.modelList = (from req in db.Requests
                                   orderby req.DateAdded
                                   select req).Skip(start).Take(end - start).ToList();
            }
            return model;
        }

        // queries database and gets most popular requests starting at index start and ending at index end
        public RequestModelList GetByMostPopular(int start, int end)
        {
            RequestModelList model = new RequestModelList();
            using (SkermData db = new SkermData())
            {
                model.modelList = (from req in db.Requests
                                   orderby req.Votes.Count
                                   select req).Skip(start).Take(end - start).ToList();
            }
            return model;
        }

        // queries database and gets all requests from a specific user starting at index start and ending at index end both inclusive
        public RequestModelList GetRequestByUser(String username, int start, int end)
        {
            RequestModelList model = new RequestModelList();
            using (SkermData db = new SkermData())
            {
                model.modelList = (from req in db.Requests
                                   where req.Username == username
                                   orderby req.IdRequest
                                   select req).Skip(start).Take(end - start).ToList();
            }
            return model;
        }

        // queries and gets a request by id
        public RequestModel GetRequestByID(int id)
        {
            RequestModel model = new RequestModel();
            using (SkermData db = new SkermData())
            {
                model.request = (from req in db.Requests
                                 where req.IdRequest == id
                                 select req).Single();
                model.votes = model.request.Votes.Count;
            }
            return model;
        }
        // queries database and gets request in language starting at index start and ending at index end both inclusive
        public RequestModelList GetRequestByLanguage(String language, int start, int end)
        {
            RequestModelList modelList = new RequestModelList();
            using (SkermData db = new SkermData())
            {
                modelList.modelList = (from req in db.Requests
                                       where req.Language.Name == language
                                       orderby req.IdRequest
                                       select req).Skip(start).Take(end - start).ToList();
            }
            return modelList;
        }
    }
}