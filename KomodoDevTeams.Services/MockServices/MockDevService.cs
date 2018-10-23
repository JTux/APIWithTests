using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoDevTeams.Models;

namespace KomodoDevTeams.Services.MockServices
{
    public class MockDevService : IDevTeamServices
    {
        public bool ReturnValue { get; set; }
        public int CallCount { get; set; }

        public bool CreateDevTeam(DevTeamCreate model)
        {
            CallCount++;
            return ReturnValue;
        }

        public bool DeleteDevTeam(int id)
        {
            CallCount--;
            return ReturnValue;
        }

        public DevTeamDetails GetDevTeamById(int id)
        {
            CallCount++;
            return new DevTeamDetails { TeamId = id };
        }

        public IEnumerable<DevTeamListItem> GetDevTeams()
        {
            CallCount++;
            var @return = new List<DevTeamListItem>
            {
                new DevTeamListItem { TeamId = 1 }
            };
            return @return;
        }

        public bool UpdateDevTeam(DevTeamEdit model)
        {
            return ReturnValue;
        }
    }
}
