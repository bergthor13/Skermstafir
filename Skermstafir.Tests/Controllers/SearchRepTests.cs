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
			// Act
			// Assert
		}

		// queries database and gets subtitles from a specific user starting at index start and ending at index end both inclusice
		[TestMethod]
		public void GetSubtitlesByUserName() {
			// Arrange
			// Act
			// Assert
		}


		// query database to get a specific subtitle
		[TestMethod]
		public void GetSubtitleByID() {
			// Arrange
			// Act
			// Assert
		}

		// query database to get subtitles by language starting at index start and ending at index end both inclusive
		[TestMethod]
		public void GetSubtitleByLanguage() {
			// Arrange
			// Act
			// Assert
		}

		// query database to get subtitles by creation year starting from start and ending with end both inclusive
		[TestMethod]
		public void GetSubtitleByCreationDate() {
			// Arrange
			// Act
			// Assert
		}


		// Query database and get a subtitles of a specified genre
		[TestMethod]
		public void GetSubtitleByGenre() {
			// Arrange
			// Act
			// Assert
		}

		// query database and get a genre by id
		[TestMethod]
		public void GetGenreByID() 
        {
			// Arrange
			// Act
			// Assert
		}

		// Query database and get a language by its name
        public void GetLanguageByName()
        {
			// Arrange
			// Act
			// Assert
        }

		[TestMethod]
		public void GetVoteByUserID()
		{
			// Arrange
			// Act
			// Assert
		}

		[TestMethod]
		public void VoteContainsSubtitle()
		{
			// Arrange
			// Act
			// Assert
		}

		[TestMethod]
		public void AddVoteToSubtite()
		{
			// Arrange
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
			// Act
			// Assert
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
