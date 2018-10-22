using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Models
{
	public class ContractDetails
	{
		public int ContractId { get; set; }
		public int DevId { get; set; }
		public int DevTeamId { get; set; }
		public DateTimeOffset EffectiveDate { get; set; }
	}
}
