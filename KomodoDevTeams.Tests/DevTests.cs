using System;
using System.Linq;
using KomodoDevTeams.Data;
using KomodoDevTeams.Models;
using KomodoDevTeams.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoDevTeams.Tests
{
	[TestClass]
	public class DevTests
	{
		private DevService _devService;
		private readonly Guid _userId;

		[TestMethod]
		public void DevServices_CreateDev_returns_correct_dev_name()
		{
			DevCreate newDev = new DevCreate()
			{
				DevName = "Zach"
			};

			_devService = new DevService(_userId);

			_devService.CreateDev(newDev);

			var expected = true;
			var actual = _devService.CreateDev(newDev);
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void DevServices_GetDevs_returns_list_of_devs()
		{
			_devService = new DevService(_userId);

			var expected = true;
			var actual = _devService.GetDevs().ToString().Contains("Tarl");
			Assert.AreEqual(expected, actual);
		}
		}
	}

