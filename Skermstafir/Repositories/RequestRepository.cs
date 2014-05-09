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

        }

        //deletes a request with a specific id
        public void DeleteRequest(int id)
        {

        }

        // queries and gets requests starting from index start and ending at index end
        public RequestModelList GetRequestByNewest(int start, int end)
        {
            RequestModelList modelList = new RequestModelList();
     
            return modelList;
        }

        // queries database and gets most popular requests starting at index start and ending at index end
        public RequestModelList GetByMostPopular(int start, int end)
        {
            RequestModelList modelList = new RequestModelList();
            return modelList;
        }

        // queries database and gets all requests from a specific user starting at index start and ending at index end both inclusive
        public RequestModelList GetRequestByUser(String username, int start, int end)
        {
            RequestModelList modelList = new RequestModelList();
            return modelList;
        }

        // queries and gets a request by id
        public RequestModel GetRequestByID(int id)
        {
            RequestModel dummy = new RequestModel();
            return dummy;
        }
        // queries database and gets request in language starting at index start and ending at index end both inclusive
        public RequestModelList GetRequestByLanguage(String language, int start, int end)
        {
            RequestModelList modelList = new RequestModelList();
            return modelList;
        }

    }
}