using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoDevTeams.Controllers;
using KomodoDevTeams.Services.MockServices;
using KomodoDevTeams.Models;
using System.Web.Http.Results;

namespace KomodoDevTeams.Tests
{
    [TestClass]
    public class DevTeamTests
    {
        private DevTeamController _controller;
        private MockDevTeamService _mockService;

        [TestInitialize]
        public void Arrange()
        {
            _mockService = new MockDevTeamService { ReturnValue = true };
            _controller = new DevTeamController(_mockService);
        }

        [TestMethod]
        public void DevTeamController_PostDevTeam_ShouldReturnOk()
        {
            var devTeam = new DevTeamCreate { TeamName = "name" };

            var result = _controller.Post(devTeam);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DevTeamController_DeleteDevTeam_ShouldReturnCorrectInt()
        {
            _mockService.CallCount = 1;

            var result = _controller.Delete(1);

            Assert.AreEqual(0, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DevTeamController_GetAll_CountShouldBeCorrectInt()
        {
            var result = _controller.GetAll();

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(
                result,
                typeof(OkNegotiatedContentResult<IEnumerable<DevTeamListItem>>)
                );
        }

        [TestMethod]
        public void DevTeamController_GetByID_CountShouldBeCorrectInt()
        {
            var result = _controller.Get(1);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<DevTeamDetails>));
        }

        [TestMethod]
        public void DevTeamController_UpdateDevTeam_CountShouldBeCorrectInt()
        {
            var newDevTeam = new DevTeamEdit { TeamName = "Name" };

            var result = _controller.Put(newDevTeam);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
