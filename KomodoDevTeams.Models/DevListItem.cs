using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Models
{
    public class DevListItem
    {
		public int DevId { get; set; }
		public string DevName { get; set; }
		public DateTimeOffset HireDate { get; set; }
		public override string ToString() => DevName;
	}
}
