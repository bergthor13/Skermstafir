using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skermstafir.Models;

namespace Skermstafir.Interfaces {
	interface ISearchRepository {
		
		// queries database to get the newest starting from start and ending at end bot inclusive
		SubtitleModelList GetSubtitleByNewest(int start, int end);

		// queries database to get a list of most popular subtitles starting at index start and ending at index end both inclusive
		SubtitleModelList GetSubtitleByMostPopular(int start, int end);

		// queries database and gets subtitles from a specific user starting at index start and ending at index end both inclusice
		SubtitleModelList GetSubtitlesByUserID(String userID);


		// query database to get a specific subtitle
		SubtitleModel GetSubtitleByID(int id);

		// query database to get subtitles by language starting at index start and ending at index end both inclusive
		SubtitleModelList GetSubtitleByLanguage(string language, int start, int end);

		// query database to get subtitles by creation year starting from start and ending with end both inclusive
		SubtitleModelList GetSubtitleByCreationDate(int startYear, int endYear, int start, int end);
	}
}
