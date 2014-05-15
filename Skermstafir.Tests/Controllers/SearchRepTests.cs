using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skermstafir;
using Skermstafir.Controllers;
using Skermstafir.Models;

namespace Skermstafir.Tests.Controllers {
	[TestClass]
	public class SearchRepTests {

		// queries database to get the newest starting from start and ending at end bot inclusive
		[TestMethod]
		public void GetSubtitleByNewest(int start, int end) {
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void GetSubtitleByString(String str) {
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		// queries database to get a list of most popular subtitles starting at index start and ending at index end both inclusive
		[TestMethod]
		public void GetSubtitleByMostPopular(int start, int end) {
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		// queries database and gets subtitles from a specific user starting at index start and ending at index end both inclusice
		[TestMethod]
		public void GetSubtitlesByUserName(String username) {
			// Arrange
			// Act
			// Assert
			// Rollback
		}


		// query database to get a specific subtitle
		[TestMethod]
		public void GetSubtitleByID(int id) {
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		// query database to get subtitles by language starting at index start and ending at index end both inclusive
		[TestMethod]
		public void GetSubtitleByLanguage(string language, int start, int end) {
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		// query database to get subtitles by creation year starting from start and ending with end both inclusive
		[TestMethod]
		public void GetSubtitleByCreationDate(int startYear, int endYear, int start, int end) {
			// Arrange
			// Act
			// Assert
			// Rollback
		}


		// Query database and get a subtitles of a specified genre
		[TestMethod]
		public void GetSubtitleByGenre(String genreName) {
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		// query database and get a genre by id
		[TestMethod]
		public void GetGenreByID(int id) 
        {
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		// Query database and get a language by its name
        public void GetLanguageByName(string name)
        {
			// Arrange
			// Act
			// Assert
			// Rollback
        }

		[TestMethod]
		public void GetVoteByUserID(string userId)
		{
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void VoteContainsSubtitle(Vote vote, Subtitle subtitle)
		{
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void AddVoteToSubtite(Vote vote, Subtitle subtitle)
		{
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void RemoveVoteFromSubtite(Vote vote, Subtitle subtitle)
		{
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void GetVotes()
		{
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void AddCommentToSub(Comment com, Subtitle sub) {
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void AddDownloadToSubtitle(Subtitle subtitle)
		{
			// Arrange
			// Act
			// Assert
			// Rollback
		}
	}
}
