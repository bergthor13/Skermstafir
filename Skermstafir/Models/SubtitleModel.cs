using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skermstafir.Models
{
    public class SubtitleModel
    {
        public Subtitle subtitle { get; set; }
		// 8 is count of genres.
		public bool[] genreValue = new bool[8];

		public SubtitleModel()
		{
			subtitle = new Subtitle();
		}
	}
}