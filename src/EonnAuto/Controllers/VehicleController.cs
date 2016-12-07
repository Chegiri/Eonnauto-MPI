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
    public class VehicleController : Controller
    {
        private VehicleService _vehicleService;

        public VehicleController(VehicleService vs)
        {
            _vehicleService = vs;
        }

        [HttpGet("{id}")]
        [Authorize]
        
        public VehicleDTO GetById(int id)
        {
            return _vehicleService.PersonalVehicle(id, User.Identity.Name);
        }
    }

}
