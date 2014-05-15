using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skermstafir;
using Skermstafir.Repositories;
using Skermstafir.Models;

namespace Skermstafir.Tests.Controllers {
	[TestClass]
	public class SearchRepTests {

		// queries database to get the newest starting from start and ending at end bot inclusive
		[TestMethod]
		public void GetSubtitleByNewest() {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			// Act
			var result = searchRep.GetSubtitleByNewest(0, 5);
			// Assert
			for (int i = 0; i < result.modelList.Count - 1; i++) {
				Assert.IsTrue(result.modelList[i].DateAdded >= result.modelList[i + 1].DateAdded);
			}

			
		}

		[TestMethod]
		public void GetSubtitleByString() {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			// Act
			var result = searchRep.GetSubtitleByString("S");
			// Assert
			foreach (var item in result.modelList) {
				Assert.IsNotNull(item.Name.Contains("S"));
			}
		}

		// queries database to get a list of most popular subtitles starting at index start and ending at index end both inclusive
		[TestMethod]
		public void GetSubtitleByMostPopular() {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			// Act
			var result = searchRep.GetSubtitleByMostPopular(0, 5);
			// Assert
			for (int i = 0; i < result.modelList.Count - 1; i++) {
				Assert.IsTrue(result.modelList[i].Votes.Count >= result.modelList[i].Votes.Count);
			}
		}

		// queries database and gets subtitles from a specific user starting at index start and ending at index end both inclusice
		[TestMethod]
		public void GetSubtitlesByUserName() {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			String user = "Elvar"; // A user we know is in the system
			// Act
			var result = searchRep.GetSubtitlesByUserName(user); 
			// Assert
			foreach (var item in result.modelList)
			{
				Assert.IsTrue(item.Username == user);
			}
		}


		// query database to get a specific subtitle
		[TestMethod]
		public void GetSubtitleByID() {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			int id = 2; // ID we know is in the database
			// Act
			var result = searchRep.GetSubtitleByID(id);
			// Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.subtitle.IdSubtitle == id);
		}

		// query database to get subtitles by language starting at index start and ending at index end both inclusive
		[TestMethod]
		public void GetSubtitleByLanguage() {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			String lang = "Íslenska";
			// Act
			var result = searchRep.GetSubtitleByLanguage(lang, 0, 5);
			// Assert
			Assert.IsNotNull(result.modelList);
			foreach (var item in result.modelList) {
				Assert.IsTrue(item.Language.Name == lang);
			}
		}

		// query database to get subtitles by creation year starting from start and ending with end both inclusive
		[TestMethod]
		public void GetSubtitleByCreationDate() {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			// Act
			var result = searchRep.GetSubtitleByCreationDate(1990, 2000, 0, 5);
			// Assert
			Assert.IsNotNull(result.modelList);
			foreach (var item in result.modelList) {
				Assert.IsTrue(item.YearCreated >= 1990 && item.YearCreated <= 2000);
			}
		}


		// Query database and get a subtitles of a specified genre
		[TestMethod]
		public void GetSubtitleByGenre() {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			Skermstafir.Genre genre = searchRep.GetGenreByID(1); // get genre from database
			// Act
			var result = searchRep.GetSubtitleByGenre(genre.Name);
			// Assert
			Assert.IsNotNull(result.modelList);
			foreach (var item in result.modelList) {
				Assert.IsTrue(item.Genres.Contains(genre));
			}
		}

		// query database and get a genre by id
		[TestMethod]
		public void GetGenreByID() 
        {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			int id = 1;
			// Act
			var result = searchRep.GetGenreByID(id);
			// Assert
			Assert.IsNotNull(result);
		}

		// Query database and get a language by its name
        public void GetLanguageByName()
        {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			String name = "Enska";
			// Act
			var result = searchRep.GetLanguageByName(name);
			// Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Name == name);
        }

		[TestMethod]
		public void GetVoteByUserID()
		{
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			String id = "46aaa95b-7a9b-49f3-9a5a-1799f2041a75"; // id that was planted in the system
			// Act
			var result = searchRep.GetVoteByUserID(id);
			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void VoteContainsSubtitle()
		{
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			var vote = searchRep.GetVoteByUserID("46aaa95b-7a9b-49f3-9a5a-1799f2041a75");
			var sub = searchRep.GetSubtitleByID(2).subtitle;
			// Act
			var result = searchRep.VoteContainsSubtitle(vote, sub);
			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void AddVoteToSubtite()
		{
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			Skermstafir.Vote vote = new Skermstafir.Vote();
			vote.UserId = "46aaa95b-7a9b-49f3-9a5a-1799f2041a75";
			Skermstafir.Subtitle sub = searchRep.GetSubtitleByID(10).subtitle;
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void RemoveVoteFromSubtite()
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
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			SearchRepository searchRep = new SearchRepository(db);
			// Act
			var result = searchRep.GetVotes();
			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void AddCommentToSub() {
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void AddDownloadToSubtitle()
		{
			// Arrange
			// Act
			// Assert
			// Rollback
		}
	}
}
