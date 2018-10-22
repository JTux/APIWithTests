using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Models
{
	public class DevCreate
	{
		[Required]
		public string DevName { get; set; }
		public override string ToString() => DevName;
	}
}
