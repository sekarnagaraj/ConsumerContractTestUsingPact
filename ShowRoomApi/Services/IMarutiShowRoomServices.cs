using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShowRoomApi.Models;

namespace ShowRoomApi.Services
{
    public interface IMarutiShowRoomServices
    {
        MarutiShowRoomModels AddNewVechicle(MarutiShowRoomModels models);
        Dictionary<int, MarutiShowRoomModels> GetAvailableVechicles();
        MarutiShowRoomModels GetSpecificVechicleByName(string name);
    }
}
