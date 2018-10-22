using KomodoDevTeams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Contracts
{
	public interface IContractService
	{
		bool CreateContract(ContractCreate model);
		IEnumerable<ContractListItem> GetContracts();
		ContractDetails GetContractById(int id);
		bool UpdateContracts(ContractEdit model);
		bool DeleteContracts(int id);
		

	}
}
