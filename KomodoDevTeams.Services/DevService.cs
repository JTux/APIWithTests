using KomodoDevTeams.Contracts;
using KomodoDevTeams.Data;
using KomodoDevTeams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Services
{
	public class DevService : IDevService
    {
		private readonly Guid _userId;

		public DevService(Guid userId)
		{
			_userId = userId;
		}
		public bool CreateDev(DevCreate model)
		{
			var entity = new Dev()
			{
				OwnerId = _userId,
				DevName = model.DevName,
				HireDate = DateTimeOffset.Now

			};

			using (var ctx = new ApplicationDbContext())
			{
				ctx.Devs.Add(entity);
				return ctx.SaveChanges() == 1;
			}
		}
		public IEnumerable<DevListItem> GetDevs()
		{
			using (var ctx = new ApplicationDbContext())
			{
				var query = ctx
								.Devs
								.Where(e => e.OwnerId == _userId)
								.Select(e => new DevListItem
								{
									DevId = e.DevId,
									DevName = e.DevName,
									HireDate = e.HireDate
								});
				return query.ToArray();
			}
		}
		public DevDetails GetDevById(int id)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity = ctx.Devs.Single(e => e.DevId == id && e.OwnerId == _userId);
				return new DevDetails
				{
					DevId = entity.DevId,
					DevName = entity.DevName,
					HireDate = entity.HireDate
				};
			}
		}
		public bool UpdateDev(DevEdit model)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity = ctx
								.Devs
								.Single(e => e.DevId == model.DevId && e.OwnerId == _userId);
				entity.DevName = model.DevName;
				entity.HireDate = model.HireDate;

				return ctx.SaveChanges() == 1;
			}
		}
		public bool DeleteDev(int id)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity = ctx
								.Devs
								.Single(e => e.DevId == id && e.OwnerId == _userId);

				ctx.Devs.Remove(entity);

				return ctx.SaveChanges() == 1;
			}
		}
	}
}
