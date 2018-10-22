using KomodoDevTeams.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Models
{
	public class ContractCreate
	{
		[Key]
		public int ContractId { get; set; }
		[Required]
		public int DevId { get; set; }
		[Required]
		public int DevTeamId { get; set; }
		[Required]
		public DateTimeOffset EffectiveDate { get; set; }
	}
}
