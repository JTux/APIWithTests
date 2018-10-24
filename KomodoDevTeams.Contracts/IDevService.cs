using KomodoDevTeams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeams.Contracts
{
    public interface IDevService
    {
        bool CreateDev(DevCreate model);
        bool DeleteDev(int id);
        DevDetails GetDevById(int id);
        IEnumerable<DevListItem> GetDevs();
        bool UpdateDev(DevEdit model);
    }
}
