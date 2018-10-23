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
	public class ContractService : IContractService
	{
		private readonly Guid _userid;

		public ContractService(Guid userid)
		{
			_userid = userid;
		}

		public bool CreateContract(ContractCreate model)
		{
			var entity = new Contract()
			{
				OwnerId = _userid,
				ContractId = model.ContractId,
				DevId = model.DevId,
				DevTeamId = model.DevTeamId
			};
			using (var ctx = new ApplicationDbContext())
			{
				ctx.Contracts.Add(entity);
				return ctx.SaveChanges() == 1;
			}
		}

		public bool DeleteContracts(int id)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity = ctx
								.Contracts
								.Single(e => e.ContractId == id && e.OwnerId == _userid);

				ctx.Contracts.Remove(entity);

				return ctx.SaveChanges() == 1;
			}
		}

		public ContractDetails GetContractById(int id)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity = ctx.Contracts.Single(e => e.ContractId == id && e.OwnerId == _userid);
				return new ContractDetails
				{
					ContractId = entity.ContractId,
					DevId = entity.DevId,
					DevTeamId = entity.DevTeamId
				};
			}
		}

		public IEnumerable<ContractListItem> GetContracts()
		{
			using (var ctx = new ApplicationDbContext())
			{
				var query = ctx
								.Contracts
								.Where(e => e.OwnerId == _userid)
								.Select(e => new ContractListItem
								{
									ContractId = e.ContractId,
									DevId = e.DevId,
									DevTeamId = e.DevTeamId
								});
				return query.ToArray();
			}
		}

		public bool UpdateContracts(ContractEdit model)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity = ctx
								.Contracts
								.Single(e => e.ContractId == model.ContractId && e.OwnerId == _userid);
				entity.ContractId = model.ContractId;
				entity.Dev.DevId = model.DevId;
				entity.DevTeamId = model.DevTeamId;

				return ctx.SaveChanges() == 1;
			}
		}
	}
	}
