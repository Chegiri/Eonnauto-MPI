using EonnAuto.Infastructure;
using EonnAuto.Models;
using EonnAuto.Services.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EonnAuto.Services
{
    public class VehicleService
    {
        private VehicleRepository _vehicileRepo;
        private UserRepository _userRepo;

        public VehicleService(VehicleRepository vr, UserRepository ur)
        {
            _vehicileRepo = vr;
            _userRepo = ur;
        }

        public IList<VehicleDTO> GetVehicleForUser(string userName)
        {
            return (from v in _vehicileRepo.GetVehicleForuser(userName)
                    select new VehicleDTO()
                    {
                        Year = v.Year,
                        Make = v.Make,
                        Model = v.Model,
                        Trim = v.Trim,
                        EngSize = v.EngSize
                    }).ToList();
        }
    }
}