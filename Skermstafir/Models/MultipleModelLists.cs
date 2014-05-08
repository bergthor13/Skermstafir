using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skermstafir.Models;
using Skermstafir.Repositories;

namespace Skermstafir.Models
{
    public class MultipleModelLists
    {
        public RequestModelList popularRequestList { get; set; }
        public RequestModelList newestRequestList { get; set; }
        public SubtitleModelList popularSubtitleList { get; set; }
        public SubtitleModelList newestSubtitleList { get; set; }

        public MultipleModelLists()
        {
            popularRequestList = new RequestModelList();
            popularSubtitleList = new SubtitleModelList();
            newestRequestList = new RequestModelList();
            newestSubtitleList = new SubtitleModelList();
        }
    }
}