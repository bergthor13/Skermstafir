using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skermstafir.Models
{
    public class RequestModelList
    {
        public List<RequestModel> modelList { get; set; }

        public RequestModelList()
        {
            modelList = new List<RequestModel>();
        }

        public void Add(RequestModel model)
        {
            modelList.Add(model);
        }
    }
}