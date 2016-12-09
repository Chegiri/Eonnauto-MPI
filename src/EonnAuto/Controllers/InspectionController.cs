﻿using System;
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
    public class InspectionController : Controller
    {
        private InspectionService _inspectionService;

        public InspectionController(InspectionService ins)
        {
            _inspectionService = ins;
        }


       [HttpPost]
       public IActionResult Add([FromBody] InspectionDTO inspection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _inspectionService.AddInspection(inspection, User.Identity.Name);
            return Ok();
        }
    }
}
    
