using KomodoDevTeams.Contracts;
using KomodoDevTeams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Services.MockServices
{
    public class MockDevService : IDevService
    {
        public bool ReturnValue { get; set; }
        public int CallCount { get; set; }

        public bool CreateDev(DevCreate model)
        {
            CallCount++;
            return ReturnValue;
        }

        public bool DeleteDev(int id)
        {
            CallCount--;
            return ReturnValue;
        }

        public DevDetails GetDevById(int id)
        {
            CallCount++;
            return new DevDetails { DevId = id };
        }

        public IEnumerable<DevListItem> GetDevs()
        {
            CallCount++;
            var @return = new List<DevListItem>
            {
                new DevListItem { DevId = 1 }
            };
            return @return;
        }

        public bool UpdateDev(DevEdit model)
        {
            CallCount++;
            return ReturnValue;
        }
    }
}
