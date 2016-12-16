using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EonnAuto.Services;
using Microsoft.AspNetCore.Authorization;
using EonnAuto.Services.ModelDTO;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EonnAuto.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private VehicleService _vehicleService;
        public InspectionService _inspectionService;

        public VehicleController(VehicleService vs, InspectionService iss)
        {
            _vehicleService = vs;
            _inspectionService = iss;
        }

        [HttpGet("{id}")]
        [Authorize]
        
        public VehicleDTO GetById(int id)
        {
            return _vehicleService.PersonalVehicle(id, User.Identity.Name);
        }

        [HttpPost("{id}/inspections")]
        public IActionResult Add([FromBody] InspectionDTO inspection, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            inspection.VehicleId = id;
            _IService.AddInspection(inspection, User.Identity.Name);
            return Ok();
        }

        [HttpPost("{id}/inspection")]
        public IActionResult Add(int id, [FromBody] InspectionDTO inspection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            inspection.VehicleId = id;
            _inspectionService.AddInspection(inspection, User.Identity.Name);
            return Ok();
        }

        [HttpGet]
        [Authorize]

        public IEnumerable<VehicleDTO> Get()
        {
            return _vehicleService.GetVehicleForUser(User.Identity.Name);
        }
        [HttpPost]
        public IActionResult Add([FromBody] VehicleDTO vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _vehicleService.AddVehicle(vehicle, User.Identity.Name);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(VehicleDTO Vehicle, int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Vehicle.Id = id;
            _vehicleService.DeleteVehicle(Vehicle, User.Identity.Name);
            return Ok();
        }
    }

}
