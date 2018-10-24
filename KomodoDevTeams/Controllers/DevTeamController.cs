using KomodoDevTeams.Contracts;
using KomodoDevTeams.Models;
using KomodoDevTeams.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace KomodoDevTeams.Controllers
{
    [Authorize]
    public class DevTeamController : ApiController
    {
        private IDevTeamService _devTeamService;

        public DevTeamController() { }
        public DevTeamController(IDevTeamService mockService)
        {
            _devTeamService = mockService;
        }

        public IHttpActionResult GetAll()
        {
            PopulateDevTeamService();
            var devTeam = _devTeamService.GetDevTeams();
            return Ok(devTeam);
        }
        public IHttpActionResult Get(int id)
        {
            PopulateDevTeamService();
            var devTeam = _devTeamService.GetDevTeamById(id);
            return Ok(devTeam);
        }
        public IHttpActionResult Post(DevTeamCreate dev)
        {
            PopulateDevTeamService();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_devTeamService.CreateDevTeam(dev))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(DevTeamEdit devTeam)
        {
            PopulateDevTeamService();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_devTeamService.UpdateDevTeam(devTeam))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            PopulateDevTeamService();
            if (!_devTeamService.DeleteDevTeam(id))
                return InternalServerError();

            return Ok();
        }

        private void PopulateDevTeamService()
        {
            if (_devTeamService == null)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var _devTeamService = new DevTeamServices(userId);
            }
        }
    }
}