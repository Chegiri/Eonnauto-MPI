using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EonnAuto.Services;
using Microsoft.AspNetCore.Authorization;
using EonnAuto.Services.ModelDTO;
using EonnAuto.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EonnAuto.Controllers
{
    [Route("api/[controller]")]
    public class InspectionController : Controller
    {
        private InspectionService _inspectionService;

        public InspectionController(InspectionService ins)
        {
            _inspectionService = ins;
        }
    

    [HttpPost]
       public IActionResult Add([FromBody] InspectionDTO inspection, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            inspection.VehicleId = id;
            _inspectionService.AddInspection(inspection, User.Identity.Name);
            return Ok();
        }
       
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInspection (InspectionDTO Inspection, int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Inspection.Id = id;
            _inspectionService.DeleteInspection(Inspection);
            return Ok();
        }
    }
}
    
