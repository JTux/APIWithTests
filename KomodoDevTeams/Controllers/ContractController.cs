using KomodoDevTeams.Contracts;
using KomodoDevTeams.Models;
using KomodoDevTeams.Services;
using KomodoDevTeams.Services.MockServices;
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
        private IContractService _contractService;

        public ContractController()
        {
            _contractService = CreateContractService();
        }
        public ContractController(IContractService mockService)
        {
            _contractService = mockService;
        }

        public IHttpActionResult GetAll()
        {
            var contract = _contractService.GetContracts();
            return Ok(contract);
        }
        public IHttpActionResult Get(int id)
        {
            var contract = _contractService.GetContractById(id);
            return Ok(contract);
        }
        public IHttpActionResult Post(ContractCreate contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_contractService.CreateContract(contract))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(ContractEdit contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_contractService.UpdateContracts(contract))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            if (!_contractService.DeleteContracts(id))
                return InternalServerError();

            return Ok();
        }
        private IContractService CreateContractService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new ContractService(userId);
        }
    }
}
