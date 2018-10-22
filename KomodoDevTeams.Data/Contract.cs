using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Data
{
	public class Contract
	{
		[Key]
		public int ContractId { get; set; }
		public Guid OwnerId { get; set; }
		public int DevId { get; set; }
		public int DevTeamId { get; set; }

		public virtual Dev Dev { get; set; }
		public virtual DevTeam DevTeam { get; set; }

	}
}
