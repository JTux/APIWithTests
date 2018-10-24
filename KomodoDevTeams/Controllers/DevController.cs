using KomodoDevTeams.Contracts;
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
        private IDevService _devService;

        public DevController() { }
        public DevController(IDevService mockService)
        {
            _devService = mockService;
        }

        public IHttpActionResult GetAll()
        {
            CreateDevService();
            var devs = _devService.GetDevs();
            return Ok(devs);
        }
        public IHttpActionResult Get(int id)
        {
            CreateDevService();
            var devs = _devService.GetDevById(id);
            return Ok(devs);
        }
        public IHttpActionResult Post(DevCreate dev)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CreateDevService();

            if (!_devService.CreateDev(dev))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(DevEdit dev)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CreateDevService();

            if (!_devService.UpdateDev(dev))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            CreateDevService();

            if (!_devService.DeleteDev(id))
                return InternalServerError();

            return Ok();
        }
        private void CreateDevService()
        {
            if (_devService == null)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                _devService = new DevService(userId);
            }
        }
    }
}
