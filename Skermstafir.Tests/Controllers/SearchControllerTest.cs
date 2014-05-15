using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skermstafir;
using Skermstafir.Controllers;

namespace Skermstafir.Tests.Controllers
{
	[TestClass]
    class SearchControllerTest
    {
		[TestMethod]
		public void Search() {
			// Arrange
			SearchController searchControl = new SearchController();
			FormCollection form = new FormCollection();
			// Act
			var result = searchControl.Search(form);
			// Assert
			Assert.IsNotNull(result);
		}
    }
}
