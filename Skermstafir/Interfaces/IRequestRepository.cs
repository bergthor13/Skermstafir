using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skermstafir.Models;

namespace Skermstafir.Interfaces {
	interface IRequestRepository {

		void AddRequest(RequestModel newRequest);

		//deletes a request with a specific id
		void DeleteRequest(int id);

		// queries and gets requests starting from index start and ending at index end
		RequestModelList GetRequestByNewest(int start, int end);

		// queries database and gets most popular requests starting at index start and ending at index end
		RequestModelList GetByMostPopular(int start, int end);

		// queries database and gets all requests from a specific user starting at index start and ending at index end both inclusive
		RequestModelList GetRequestsByUser(String userName);

		// queries and gets a request by id
		RequestModel GetRequestByID(int id);
		// queries database and gets request in language starting at index start and ending at index end both inclusive
		RequestModelList GetRequestByLanguage(String language, int start, int end);
	}
}
