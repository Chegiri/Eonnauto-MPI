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
        private VehicleRepository _vehicleRepo;
        private UserRepository _userRepo;

        public VehicleService(VehicleRepository vr, UserRepository ur)
        {
            _vehicleRepo = vr;
            _userRepo = ur;
        }

        public IList<VehicleDTO> GetVehicleForUser(string userName)
        {
            return (from v in _vehicleRepo.GetVehicleForuser(userName)
                    select new VehicleDTO()
                    {
                        Id = v.Id,
                        VehiceUrl = v.VehiceUrl,
                        Year = v.Year,
                        Make = v.Make,
                        Model = v.Model,
                        Trim = v.Trim,
                        EngSize = v.EngSize,
                    }).ToList();
        }
        public VehicleDTO PersonalVehicle(int Id, string user)
        {
            return (from v in _vehicleRepo.GetVehicleById(Id, user)
                    select new VehicleDTO()
                    {
                        Id = v.Id,
                        VehiceUrl = v.VehiceUrl,
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
                                          AirFilter = i.AirFilter,
                                          CabinFilter = i.CabinFilter,
                                          DriveBelt = i.DriveBelt,
                                          Exhaust = i.Exhaust,
                                          FrontBrakes = i.FrontBrakes,
                                          FrontHeadLights = i.FrontHeadLights,
                                          FrontRotors = i.FrontRotors,
                                          FrontSignals = i.FrontSignals,
                                          FrontSuspension = i.FrontSuspension,
                                          FrontTires = i.FrontTires,
                                          FrontWheels = i.FrontWheels,
                                          Horn = i.Horn,
                                          RearBrakes = i.RearBrakes,
                                          RearRotors = i.RearRotors,
                                          RearStopLights = i.RearStopLights,
                                          RearSuspension = i.RearSuspension,
                                          RearTires = i.RearTires,
                                          RearWheels = i.RearWheels,
                                          Steering = i.Steering, 
                                          Wipers = i.Wipers
                                      }).ToList()

                    }).FirstOrDefault();
        }

        public void AddVehicle(VehicleDTO vehicle, string currentUser)
        {
            Vehicle dbVehicle = new EonnAuto.Models.Vehicle()
            {
                Id = vehicle.Id,
                VehiceUrl = vehicle.VehiceUrl,
                Year = vehicle.Year,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Trim = vehicle.Trim,
                EngSize = vehicle.EngSize,
                UserId = _userRepo.GetUser(currentUser).First().Id
            };
            _vehicleRepo.Add(dbVehicle);
        }
        public VehicleDTO FindById(int id, string user)
        {
            return (from v in _vehicleRepo.GetVehicleById(id, user)
                    select new VehicleDTO
                    {
                        Id = v.Id,
                        VehiceUrl = v.VehiceUrl,
                        Year = v.Year,
                        Make = v.Make,
                        Model = v.Model,
                        Trim = v.Trim,
                        EngSize = v.EngSize
                    }).FirstOrDefault();
        }
        public void DeleteVehicle(VehicleDTO Vehicle, string currentuser)
        {
            _vehicleRepo.DeleteVehicle(_vehicleRepo.GetVehicleById(Vehicle.Id, currentuser).First(), currentuser);
        }
    }
}