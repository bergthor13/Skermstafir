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
            // bellow is dummy code
            for (int i = 0; i < end - start; i++)
            {
                RequestModel dummy = new RequestModel();
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.votes = 32;
                dummy.yearCreated = 2014;
                dummy.dateAdded = DateTime.Now;
				dummy.Language = "Íslenska";
                dummy.artists.Add("Bruce Willis");
				dummy.description = "None";
				dummy.user = "YOOOUUUU!!!!!";
                modelList.Add(dummy);
            }
            return modelList;
        }

        // queries database and gets most popular requests starting at index start and ending at index end
        public RequestModelList GetByMostPopular(int start, int end)
        {
            RequestModelList modelList = new RequestModelList();
            //Bellow is dummy code
            for (int i = 0; i < end - start; i++)
            {
                RequestModel dummy = new RequestModel();
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.votes = 25;
                dummy.yearCreated = 2014;
                dummy.dateAdded = DateTime.Now;
                dummy.Language = "Íslenska";
                dummy.artists.Add("Bruce Willis");
                dummy.description = "None";
                dummy.user = "YOOOUUUU!!!!!";
                modelList.Add(dummy);
            }
            return modelList;
        }

        // queries database and gets all requests from a specific user starting at index start and ending at index end both inclusive
        public RequestModelList GetRequestByUser(String username, int start, int end)
        {
            RequestModelList modelList = new RequestModelList();
            for (int i = 0; i < end - start; i++)
            {
                RequestModel dummy = new RequestModel();
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.votes = 25;
                dummy.yearCreated = 2014;
                dummy.dateAdded = DateTime.Now;
                dummy.Language = "Íslenska";
                dummy.artists.Add("Bruce Willis");
                dummy.description = "None";
                dummy.user = "YOOOUUUU!!!!!";
                modelList.Add(dummy);
            }
            return modelList;
        }

        // queries and gets a request by id
        public RequestModel GetRequestByID(int id)
        {
            RequestModel dummy = new RequestModel();
            dummy.name = "Anchorman 2, The Legend Continues";
            dummy.votes = 25;
            dummy.yearCreated = 2014;
            dummy.dateAdded = DateTime.Now;
            dummy.Language = "Íslenska";
            dummy.artists.Add("Bruce Willis");
            dummy.description = "None";
            dummy.user = "YOOOUUUU!!!!!";
            return dummy;
        }
        // queries database and gets request in language starting at index start and ending at index end both inclusive
        public RequestModelList GetRequestByLanguage(String language, int start, int end)
        {
            RequestModelList modelList = new RequestModelList();
            for (int i = 0; i < end - start; i++)
            {
                RequestModel dummy = new RequestModel();
                dummy.name = "Anchorman 2, The Legend Continues";
                dummy.votes = 25;
                dummy.yearCreated = 2014;
                dummy.dateAdded = DateTime.Now;
                dummy.Language = "Íslenska";
                dummy.artists.Add("Bruce Willis");
                dummy.description = "None";
                dummy.user = "YOOOUUUU!!!!!";
                modelList.Add(dummy);
            }
            return modelList;
        }

    }
}