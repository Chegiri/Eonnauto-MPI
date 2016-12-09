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
                        Inspection = (from i in v.Inspections
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

        public void AddVehicle(VehicleDTO vehicle, string currentUser)
        {
            Vehicle dbVehicle = new EonnAuto.Models.Vehicle()
            {
                Id = vehicle.Id,
                Year = vehicle.Year,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Trim = vehicle.Trim,
                EngSize = vehicle.EngSize,
                UserId = _userRepo.GetUser(currentUser).First().Id
            };
            _vehicileRepo.Add(dbVehicle);
        }
        public VehicleDTO FindById(int id, string user)
        {
            return (from v in _vehicileRepo.GetVehicleById(id, user)
                    select new VehicleDTO
                    {
                        Id = v.Id,
                        Year = v.Year,
                        Make = v.Make,
                        Model = v.Model,
                        Trim = v.Trim,
                        EngSize = v.EngSize
                    }).FirstOrDefault();
        }
    }
}