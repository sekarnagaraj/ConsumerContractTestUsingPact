using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShowRoomApi.Models;

namespace ShowRoomApi.Services
{
    public class MarutiShowRoomServices : IMarutiShowRoomServices
    {
        private readonly Dictionary<int, MarutiShowRoomModels> _showRoomModels;
        public MarutiShowRoomServices()
        {
            _showRoomModels = new Dictionary<int, MarutiShowRoomModels>();
        }

        public MarutiShowRoomModels AddNewVechicle(MarutiShowRoomModels models)
        {
            _showRoomModels.Add(models.VechicleId, models);
            return models;
        }

        public MarutiShowRoomModels GetSpecificVechicleByName(string name)
        {
            return _showRoomModels.Where(c => c.Value.VechicleName == name).FirstOrDefault().Value;
        }

        Dictionary<int, MarutiShowRoomModels> IMarutiShowRoomServices.GetAvailableVechicles()
        {
            return _showRoomModels;
        }
    }
}
