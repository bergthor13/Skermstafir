using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skermstafir;
using Skermstafir.Controllers;

namespace Skermstafir.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void Index()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

        [TestMethod]
        public void Instructions()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            ViewResult result = controller.Instructions() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Requests()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Requests() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Subtitles()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Subtitles() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
	}
}
