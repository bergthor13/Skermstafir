using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skermstafir.Models;

namespace Skermstafir.Interfaces {
	interface ISubtitleRepository {

		void AddSubtitle(SubtitleModel model);

		// Delete a specific subtitle from database
		void DeleteSubtitle(int id);

		// Change an existing subtitle entry in the database
		void ChangeExistingSubtitle(int id, SubtitleModel editSub);
	}
}
