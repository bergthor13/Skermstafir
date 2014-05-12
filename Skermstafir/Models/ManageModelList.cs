using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skermstafir.Models
{
    public class ManageModelList
    {
        public SubtitleModelList subList { get; set; }
        public RequestModelList reqList { get; set; }
        public ManageModelList()
        {
            subList = new SubtitleModelList();
            reqList = new RequestModelList();
        }
    }
}