using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication21.Models
{
	public class Image
	{
		public int Id { get; set; }
		public string ImageSrc { get; set; }
		public string ImageText { get; set; }
	
		public int UserId { get; set; }

		
	}
}
