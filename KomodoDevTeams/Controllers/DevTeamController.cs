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
    public class DevTeamController : ApiController
    {
		public IHttpActionResult GetAll()
		{
			DevTeamServices devTeamService = CreateDevTeamService();
			var devTeam = devTeamService.GetDevTeams();
			return Ok(devTeam);
		}
		public IHttpActionResult Get(int id)
		{
			DevTeamServices devTeamService = CreateDevTeamService();
			var devTeam = devTeamService.GetDevTeamById(id);
			return Ok(devTeam);
		}
		public IHttpActionResult Post(DevTeamCreate dev)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var service = CreateDevTeamService();

			if (!service.CreateDevTeam(dev))
				return InternalServerError();
			return Ok();
		}
		public IHttpActionResult Put(DevTeamEdit devTeam)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var service = CreateDevTeamService();

			if (!service.UpdateDevTeam(devTeam))
				return InternalServerError();

			return Ok();
		}
		public IHttpActionResult Delete(int id)
		{
			var service = CreateDevTeamService();

			if (!service.DeleteDevTeam(id))
				return InternalServerError();

			return Ok();
		}
		private DevTeamServices CreateDevTeamService()
		{
			var userId = Guid.Parse(User.Identity.GetUserId());
			var devTeamSerivce = new DevTeamServices(userId);
			return devTeamSerivce;
		}
	}
}
