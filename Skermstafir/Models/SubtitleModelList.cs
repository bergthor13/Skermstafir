using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skermstafir.Models
{
    public class SubtitleModelList
    {
        public List<SubtitleModel> modelList { get; set; }

        public SubtitleModelList()
        {
            modelList = new List<SubtitleModel>();
        }

        public void Add(SubtitleModel model){
            modelList.Add(model);
        }
    }
}