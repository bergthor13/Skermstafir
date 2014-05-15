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
			// Act
			// Assert
			// Rollback
        }

        // queries database and gets most popular requests starting at index start and ending at index end
		[TestMethod]
        public void GetByMostPopular()
        {
			// Arrange
			// Act
			// Assert
			// Rollback
        }

        // queries database and gets all requests from a specific user starting at index start and ending at index end both inclusive
		[TestMethod]
        public void GetRequestsByUser()
        {
			// Arrange
			// Act
			// Assert
			// Rollback
        }

        // queries and gets a request by id
		[TestMethod]
        public void GetRequestByID()
        {
			// Arrange
			// Act
			// Assert
			// Rollback
        }

        // queries database and gets request in language starting at index start and ending at index end both inclusive
		[TestMethod]
        public void GetRequestByLanguage()
        {
			// Arrange
			// Act
			// Assert
			// Rollback
        }

		[TestMethod]
		public void GetRequestsByString() {
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void GetRequestsByYear() {
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void GetRequestsByGenre() {
			// Arrange
			// Act
			// Assert
			// Rollback
		}

		[TestMethod]
		public void VoteContainsRequest()
		{
			// Arrange
			// Act
			// Assert
			// Rollback
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
			// Act
			// Assert
			// Rollback
		}
	}
}
