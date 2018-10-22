using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Data
{
    public class Dev
    {
		[Key]
		public int DevId { get; set; }
		[Required]
		public Guid OwnerId { get; set; }
		[Required]
		public string DevName { get; set; }
		[Required]
		public DateTimeOffset HireDate { get; set; }

		public virtual DevTeam DevTeam { get; set; }
	}
}
