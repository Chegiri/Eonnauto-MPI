using EonnAuto.Infastructure;
using EonnAuto.Models;
using EonnAuto.Services.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EonnAuto.Services
{
    public class InspectionService
    {
        private InspectionRepository _inspectionRepo;
        private VehicleRepository _vehicleRepo;

        public InspectionService(InspectionRepository ir, VehicleRepository vr)
        {
            _inspectionRepo = ir;
            _vehicleRepo = vr;
        }
        public IList<InspectionDTO> GetInspectionForVehicle(int Id)
        {
            return (from i in _inspectionRepo.GetInspectionForvehicle(Id)
                    select new InspectionDTO()
                    {
                        Id = i.Id,
                        VehicleId = i.VehicleId,
                        Date = i.Date,
                        Mileage = i.Mileage,
                        Brake = i.Brake,
                        Rotor = i.Rotor,
                        Tire = i.Tire,
                        Shock = i.Shock,
                    }).ToList();
        }
        public void AddInspection(InspectionDTO inspection, string currentUser)
        {
            Inspection dbInspection = new EonnAuto.Models.Inspection()
            {
                Id = inspection.Id,
                VehicleId = _vehicleRepo.GetVehicleById(inspection.VehicleId, currentUser).First().Id,
                Date = inspection.Date,
                Mileage = inspection.Mileage,
                Brake = inspection.Brake,
                Rotor = inspection.Rotor,
                Tire = inspection.Tire,
                Shock = inspection.Shock,
                
            };
            _inspectionRepo.Add(dbInspection);
        }
        public InspectionDTO FindById(int vehicleId)
        {
            return (from i in _inspectionRepo.GetInspectionForvehicle(vehicleId)
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
                    }).FirstOrDefault();
        }
        public void DeleteInspection(InspectionDTO Inspection)
        {
            _inspectionRepo.DeleteInspection(_inspectionRepo.GetInspectionById(Inspection.Id).First());
        }
    }
    
}
