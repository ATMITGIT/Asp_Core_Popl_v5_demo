using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication21.Models
{
	public class ChangeSettings
	{
		public int Id { get; set; }
		public int Link { get; set; }
		public string NewPassword { get; set; }
		public string NewPasswordConfirm { get; set; }
	}
}
