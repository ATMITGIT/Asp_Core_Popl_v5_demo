using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication21.Models
{
	public class User
	{
		public int Id { get; set; }
		public int Link { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int NewGuidUser { get; set; }

		public string ProfImage { get; set; }
		
		//public Dictionary<string, string> image { get; set; }

		/*public List<string> ImageSrc { get; set; }
		public List<string> ImageText { get; set; }*/

	}
}
