using KomodoDevTeams.Models;
using KomodoDevTeams.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KomodoDevTeams.WebAPI.Controllers
{
	[Authorize]
    public class DevController : ApiController
    {
		public IHttpActionResult GetAll()
		{
			DevService devService = CreateDevService();
			var devs = devService.GetDevs();
			return Ok(devs);
		}
		public IHttpActionResult Get(int id)
		{
			DevService devService = CreateDevService();
			var devs = devService.GetDevById(id);
			return Ok(devs);
		}
		public IHttpActionResult Post(DevCreate dev)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var service = CreateDevService();

			if (!service.CreateDev(dev))
				return InternalServerError();
			return Ok();
		}
		public IHttpActionResult Put(DevEdit dev)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var service = CreateDevService();

			if (!service.UpdateDev(dev))
				return InternalServerError();

			return Ok();
		}
		public IHttpActionResult Delete(int id)
		{
			var service = CreateDevService();

			if (!service.DeleteDev(id))
				return InternalServerError();

			return Ok();
		}
		private DevService CreateDevService()
		{
			var userId = Guid.Parse(User.Identity.GetUserId());
			var devSerivce = new DevService(userId);
			return devSerivce;
		}
    }
}
