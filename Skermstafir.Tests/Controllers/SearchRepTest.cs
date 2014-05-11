using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skermstafir.Repositories;
using Skermstafir.Models;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Skermstafir.Tests.Controllers
{
    class SearchRepTest
    {
        [TestMethod]
        public void GetSubtitleByNewest()
        {
            // Arrange
            SearchRepository searchRep = new SearchRepository();
            // Act
            // numbers passed to function choosen to provide a set number of result
            SubtitleModelList result = searchRep.GetSubtitleByNewest(0, 5);
            // Assert
            for (int i = 0; i < result.modelList.Count - 1; i++)
            {
                // check to see if the list is ordered corredtily
                // if date is"more"/"earlier" than the other ... 8/1/2009 12:00:00 AM > 8/1/2009 12:00:00 PM
                // if result is null this will evaluate to false
                Assert.IsTrue(result.modelList[i].DateAdded >= result.modelList[i + 1].DateAdded);
            }
        }

        [TestMethod]
        public void GetSubtitleByMostPopular()
        {
            // Arrange
            SearchRepository searchRep = new SearchRepository();
            // Act
            SubtitleModelList result = searchRep.GetSubtitleByMostPopular(0, 5);
            // Assert
            for (int i = 0; i < result.modelList.Count - 1; i++)
            {
                // Check to see if list is ordered correctly
                // entry I should have more or equal votes than entry I + 1
                // if result is null this will evaluate to false
                Assert.IsTrue(result.modelList[i].Votes.Count >= result.modelList[i + 1].Votes.Count);
            }
        }

        [TestMethod]
        public void GetSubtitleByUser()
        {
            // Arrange
            SearchRepository searchRep = new SearchRepository();
            String user = "Elvar"; // a User we know is in the database
            // Act
            SubtitleModelList result = searchRep.GetSubtitleByUser(user, 0, 3);
            // Assert
            for (int i = 0; i < result.modelList.Count; i++)
            {
                // check to see if all result are linked to the same user
                // if result is null this will evaluate to false
                Assert.IsTrue(result.modelList[i].AspNetUsers.First().UserName == user);
            }
        }
        [TestMethod]
        public void GetSubtitleByID()
        {
            // Arrange
            SearchRepository searchRep = new SearchRepository();
            // Act
            SubtitleModel result = searchRep.GetSubtitleByID(1);
            // Assert
            // check the ID of the subtitle we Recieved
            // if result is null this will evaluate to false
            Assert.IsTrue(result.subtitle.IdSubtitle == 1);
        }
        [TestMethod]
        public void GetSubtitleByLanguage()
        {
            // Arrange
            SearchRepository searchRep = new SearchRepository();
            String language = "Íslenska";
            // Act
            SubtitleModelList result = searchRep.GetSubtitleByLanguage(language, 0, 5);
            // Assert
            for (int i = 0; i < result.modelList.Count; i++)
            {
                // Check if all subtitles in result has the desired language
                // if result is null this will evaluate false
                Assert.IsTrue(result.modelList[i].Language.Name == language);
            }
        }

		[TestMethod]
		public void GetSubtitleByCreationDate() {
			// Arrange
			SearchRepository searchRep = new SearchRepository();
			int startYear = 2000;
			int endYear = 2014;
			// Act
			SubtitleModelList result = searchRep.GetSubtitleByCreationDate(startYear, endYear, 0, 2);
			// Assert
			for (int i = 0; i < result.modelList.Count; i++) {
				Assert.IsTrue(result.modelList[i].YearCreated >= startYear
								&& result.modelList[i].YearCreated >= endYear);
			}
		}
    }
}
