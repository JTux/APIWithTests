using KomodoDevTeams.Data;
using KomodoDevTeams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Services
{
	public class DevTeamServices
	{
		private readonly Guid _userId;

		public DevTeamServices(Guid userid)
		{
			_userId = userid;
		}
		public bool CreateDevTeam(DevTeamCreate model)
		{
			var entity = new DevTeam()
			{
				OwnerId = _userId,
				TeamName = model.TeamName
			};

			using (var ctx = new ApplicationDbContext())
			{
				ctx.DevTeams.Add(entity);
				return ctx.SaveChanges() == 1;
			}
		}
		public IEnumerable<DevTeamListItem> GetDevTeams()
		{
			using (var ctx = new ApplicationDbContext())
			{
				var query = ctx
								.DevTeams
								.Where(e => e.OwnerId == _userId)
								.Select(e => new DevTeamListItem
								{
									TeamId = e.TeamId,
									TeamName = e.TeamName
								});
				return query.ToArray();
			}
		}
		public DevTeamDetails GetDevTeamById(int id)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity = ctx.DevTeams.Single(e => e.TeamId == id && e.OwnerId == _userId);
				return new DevTeamDetails
				{
					TeamId = entity.TeamId,
					TeamName = entity.TeamName
				};
			}
		}
		public bool UpdateDevTeam(DevTeamEdit model)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity = ctx
								.DevTeams
								.Single(e => e.TeamId == model.TeamId && e.OwnerId == _userId);
				entity.TeamId = model.TeamId;
				entity.TeamName = model.TeamName;

				return ctx.SaveChanges() == 1;
			}
		}
		public bool DeleteDevTeam(int id)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity = ctx
								.DevTeams
								.Single(e => e.TeamId == id && e.OwnerId == _userId);

				ctx.DevTeams.Remove(entity);

				return ctx.SaveChanges() == 1;
			}
		}
	}
}
