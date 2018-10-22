using KomodoDevTeams.Models;
using KomodoDevTeams.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KomodoDevTeams.Controllers
{
	[Authorize]
    public class ContractController : ApiController
    {
		public IHttpActionResult GetAll()
		{
			ContractService contractService = CreateContractService();
			var contract = contractService.GetContracts();
			return Ok(contract);
		}
		public IHttpActionResult Get(int id)
		{
			ContractService contractService = CreateContractService();
			var contract = contractService.GetContractById(id);
			return Ok(contract);
		}
		public IHttpActionResult Post(ContractCreate contract)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var service = CreateContractService();

			if (!service.CreateContract(contract))
				return InternalServerError();
			return Ok();
		}
		public IHttpActionResult Put(ContractEdit contract)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var service = CreateContractService();

			if (!service.UpdateContracts(contract))
				return InternalServerError();

			return Ok();
		}
		public IHttpActionResult Delete(int id)
		{
			var service = CreateContractService();

			if (!service.DeleteContracts(id))
				return InternalServerError();

			return Ok();
		}
		private ContractService CreateContractService()
		{
			var userId = Guid.Parse(User.Identity.GetUserId());
			var contractService = new ContractService(userId);
			return contractService;
		}
    }
}
