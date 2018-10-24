using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoDevTeams.Controllers;
using KomodoDevTeams.Services.MockServices;
using KomodoDevTeams.Models;
using System.Web.Http.Results;
using KomodoDevTeams.WebAPI.Controllers;

namespace KomodoDevTeams.Tests
{
    [TestClass]
    public class DevTests
    {
        private DevController _controller;
        private MockDevService _mockService;

        [TestInitialize]
        public void Arrange()
        {
            _mockService = new MockDevService { ReturnValue = true };
            _controller = new DevController(_mockService);
        }

        [TestMethod]
        public void DevController_PostDev_ShouldReturnOk()
        {
            var dev = new DevCreate { DevName = "name" };

            var result = _controller.Post(dev);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DevController_DeleteDev_ShouldReturnCorrectInt()
        {
            _mockService.CallCount = 1;

            var result = _controller.Delete(1);

            Assert.AreEqual(0, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DevController_GetAll_CountShouldBeCorrectInt()
        {
            var result = _controller.GetAll();

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(
                result,
                typeof(OkNegotiatedContentResult<IEnumerable<DevListItem>>)
                );
        }

        [TestMethod]
        public void DevController_GetByID_CountShouldBeCorrectInt()
        {
            var result = _controller.Get(1);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<DevDetails>));
        }

        [TestMethod]
        public void DevController_UpdateDev_CountShouldBeCorrectInt()
        {
            var newDev = new DevEdit { DevName = "Name" };

            var result = _controller.Put(newDev);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
