using System;
using System.Linq;
using System.Web.Http.Results;
using KomodoDevTeams.Controllers;
using KomodoDevTeams.Data;
using KomodoDevTeams.Models;
using KomodoDevTeams.Services;
using KomodoDevTeams.Services.MockServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoDevTeams.Tests
{
    [TestClass]
    public class ContractTests
    {
        private ContractController _controller;
        private MockContractService _mockService;

        [TestInitialize]
        public void Arrange()
        {
            _mockService = new MockContractService();
            _controller = new ContractController(_mockService);
        }

        [TestMethod]
        public void ContractController_PostContract_ShouldReturnOk()
        {
            _mockService.ReturnValue = true;
            var contract = new ContractCreate { ContractId = 1 };

            var result = _controller.Post(contract);

            Assert.IsInstanceOfType(result, typeof(OkResult));
            Assert.AreEqual(1, _mockService.CallCount);
        }

        [TestMethod]
        public void ContractController_DeleteContract_ShouldReturnCorrectInt()
        {
            _mockService.ReturnValue = true;
            _mockService.CallCount = 1;

            var result = _controller.Delete(1);

            Assert.IsInstanceOfType(result, typeof(OkResult));
            Assert.AreEqual(0, _mockService.CallCount);
        }
    }
}