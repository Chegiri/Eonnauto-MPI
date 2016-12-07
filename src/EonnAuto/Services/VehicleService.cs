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
                        Id = v.Id,
                        Year = v.Year,
                        Make = v.Make,
                        Model = v.Model,
                        Trim = v.Trim,
                        EngSize = v.EngSize,
                    }).ToList();
        }
        public VehicleDTO PersonalVehicle(int Id, string user)
        {
            return (from v in _vehicileRepo.GetVehicleById(Id, user)
                    select new VehicleDTO()
                    {
                        Id = v.Id,
                        Year = v.Year,
                        Make = v.Make,
                        Model = v.Model,
                        Trim = v.Trim,
                        EngSize = v.EngSize,
                        Inspection = (from i in v.Inspection
                                      select new InspectionDTO
                                      {
                                          Id = i.Id,
                                          VehicleId = i.VehicleId,
                                          Date = i.Date,
                                          Mileage = i.Mileage,
                                          Brake = i.Brake,
                                          Rotor = i.Rotor,
                                          Tire = i.Tire,
                                          Shock = i.Shock

                                      }).ToList()

                    }).FirstOrDefault();
        }
    }
}