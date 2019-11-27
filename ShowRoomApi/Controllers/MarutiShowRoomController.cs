using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowRoomApi.Models;
using ShowRoomApi.Services;

namespace ShowRoomApi.Controllers
{
    [Route("microservice/")]
    [ApiController]
    public class MarutiShowRoomController : ControllerBase
    {
        private readonly IMarutiShowRoomServices _services;
        public MarutiShowRoomController(IMarutiShowRoomServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("Values")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value2", "value3" };
        }

        //GET api/values
        [HttpGet]
        [Route("GetAvailableModels")]
        public ActionResult<Dictionary<int, MarutiShowRoomModels>> GetAvailableModels()
        {
            var availableModels = _services.GetAvailableVechicles();
            if (availableModels == null)
            {
                return NotFound();
            }
            return availableModels;
        }

        //GET api/values
        [HttpGet]
        [Route("GetSpecificModel/{Name}")]
        public ActionResult<MarutiShowRoomModels> GetSpecificVechicleByName(string Name)
        {
            var availableModels = _services.GetSpecificVechicleByName(Name);
            
            if (availableModels == null)
            {
                return NotFound();
            }
            return availableModels;
        }

        [HttpPost]
        [Route("AddNewModel")]
        public ActionResult<MarutiShowRoomModels> AddNewModelToShowRoom(MarutiShowRoomModels models)
        {
            var newModels = _services.AddNewVechicle(models);
            if(models == null)
            {
                return NotFound();
            }
            return models;
        }          
    }
}
