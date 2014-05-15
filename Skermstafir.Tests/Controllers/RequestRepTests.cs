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
	public class RequestRepTests {
        // adds new request to database
		[TestMethod]
        public void AddRequest(RequestModel newRequest)
        {
			// Arrange
			// Act
			// Assert
			// Rollback
        }

        //deletes a request with a specific id
		[TestMethod]
        public void DeleteRequest()
        {
			// Arrange
			// Act
			// Assert
			// Rollback
        }

        // queries and gets requests starting from index start and ending at index end
		[TestMethod]
        public void GetRequestByNewest()
        {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			RequestRepository reqRep = new RequestRepository(db);
			// Act
			var result = reqRep.GetRequestByNewest(0, 5);
			// Assert
			Assert.IsNotNull(result.modelList);
			for (int i = 0; i < result.modelList.Count - 1; i++) {
				Assert.IsTrue(result.modelList[i].DateAdded >= result.modelList[i + 1].DateAdded);
			}
        }

        // queries database and gets most popular requests starting at index start and ending at index end
		[TestMethod]
        public void GetByMostPopular()
        {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			RequestRepository reqRep = new RequestRepository(db);
			// Act
			var result = reqRep.GetByMostPopular(0, 5);
			// Assert
			Assert.IsNotNull(result.modelList);
			for (int i = 0; i < result.modelList.Count - 1; i++) {
				Assert.IsTrue(result.modelList[i].Votes.Count >= result.modelList[i + 1].Votes.Count);
			}
        }

        // queries database and gets all requests from a specific user starting at index start and ending at index end both inclusive
		[TestMethod]
        public void GetRequestsByUser()
        {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			RequestRepository reqRep = new RequestRepository(db);
			String user = "Elvar";
			// Act
			var result = reqRep.GetRequestsByUser(user);
			// Assert
			Assert.IsNotNull(result.modelList);
			foreach (var item in result.modelList) {
				Assert.IsTrue(item.Username == user);
			}
        }

        // queries and gets a request by id
		[TestMethod]
        public void GetRequestByID()
        {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			RequestRepository reqRep = new RequestRepository(db);
			int id = 1;
			// Act
			var result = reqRep.GetRequestByID(id);
			// Assert
			Assert.IsNotNull(result);
        }

        // queries database and gets request in language starting at index start and ending at index end both inclusive
		[TestMethod]
        public void GetRequestByLanguage()
        {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			RequestRepository reqRep = new RequestRepository(db);
			String lang = "Íslenska";
			// Act
			var result = reqRep.GetRequestByLanguage(lang, 0, 5);
			// Assert
			Assert.IsNotNull(result.modelList);
			foreach (var item in result.modelList) {
				Assert.IsTrue(item.Language.Name == lang);
			}
        }

		[TestMethod]
		public void GetRequestsByString() {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			RequestRepository reqRep = new RequestRepository(db);
			String name = "s";
			// Act
			var result = reqRep.GetRequestsByString(name);
			// Assert
			Assert.IsNotNull(result.modelList);
			foreach (var item in result.modelList) {
				Assert.IsTrue(item.Name.Contains(name));
			}
		}

		[TestMethod]
		public void GetRequestsByYear() {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			RequestRepository reqRep = new RequestRepository(db);
			int start = 1990;
			int end = 2000;
			// Act
			var result = reqRep.GetRequestsByYear(start, end);
			// Assert
			Assert.IsNotNull(result.modelList);
			foreach (var item in result.modelList) {
				Assert.IsTrue(item.YearCreated >= start && item.YearCreated <= end);
			}
		}

		[TestMethod]
		public void GetRequestsByGenre() {
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			RequestRepository reqRep = new RequestRepository(db);
			SearchRepository search = new SearchRepository(db);
			Skermstafir.Genre genre = search.GetGenreByID(2);
			// Act
			var result = reqRep.GetRequestsByGenre(genre.Name);
			// Assert
			Assert.IsNotNull(result.modelList);
			foreach (var item in result.modelList) {
				Assert.IsTrue(item.Genres.Contains(genre));
			}
		}

		[TestMethod]
		public void VoteContainsRequest()
		{
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			RequestRepository reqRep = new RequestRepository(db);
			Skermstafir.Request req = reqRep.GetRequestByID(2).request;
			Skermstafir.Vote vote = reqRep.GetVoteByUserID("35d6a087-7485-4517-8a23-fbed72ef60d4");
			// Act
			var result = reqRep.VoteContainsRequest(vote, req);
			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void AddVoteToRequest()
		{
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void RemoveVoteFromRequest()
		{
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void GetVoteByUserID()
		{
			// Arrange
			Skermstafir.SkermData db = new Skermstafir.SkermData();
			RequestRepository reqRep = new RequestRepository(db);
			String user = "35d6a087-7485-4517-8a23-fbed72ef60d4";
			// Act
			var result = reqRep.GetVoteByUserID(user);
			// Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.UserId == user);
		}
	}
}
