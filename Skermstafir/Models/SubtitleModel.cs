using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skermstafir.Models
{
    public class SubtitleModel
    {
        public Subtitle subtitle { get; set; }
		public bool[] genreValue = new bool[8];
		public char[] charArr = new char[8];
		public string artistsForView;
		public SubtitleModel()
		{
			subtitle = new Subtitle();
		}
	}


}