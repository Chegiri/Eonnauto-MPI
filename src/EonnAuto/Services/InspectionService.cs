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
                        RearBrakes =i.RearBrakes,
                        RearRotors = i.RearRotors,
                        RearStopLights = i.RearStopLights,
                        RearSuspension = i.RearSuspension,
                        RearTires = i.RearTires,
                        RearWheels = i.RearWheels,
                        Steering = i.Steering,
                        Wipers = i.Wipers
                        
                    }).ToList();
        }
        public void AddInspection(InspectionDTO inspection, string currentUser)
        {
            Inspection dbInspection = new /*EonnAuto.Models.*/Inspection()
            {
                Id = inspection.Id,
                VehicleId = _vehicleRepo.GetVehicleById(inspection.VehicleId, currentUser).First().Id,
                Date = DateTime.Now,
                Mileage = inspection.Mileage,
                AirFilter = inspection.AirFilter,
                CabinFilter = inspection.CabinFilter,
                DriveBelt = inspection.DriveBelt,
                Exhaust = inspection.Exhaust,
                FrontBrakes = inspection.FrontBrakes,
                FrontHeadLights = inspection.FrontHeadLights,
                FrontRotors = inspection.FrontRotors,
                FrontSignals = inspection.FrontSignals,
                FrontSuspension = inspection.FrontSuspension,
                FrontTires = inspection.FrontTires,
                FrontWheels = inspection.FrontWheels,
                Horn = inspection.Horn,
                RearBrakes = inspection.RearBrakes,
                RearRotors = inspection.RearRotors,
                RearStopLights = inspection.RearStopLights,
                RearSuspension = inspection.RearSuspension,
                RearTires = inspection.RearTires,
                RearWheels = inspection.RearWheels,
                Steering = inspection.Steering,
                Wipers = inspection.Wipers
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
                    }).FirstOrDefault();
        }
        public void EditInspection(InspectionDTO inspection)
        {
            Inspection dbInspection = _inspectionRepo.GetInspectionById(inspection.Id).FirstOrDefault();

            dbInspection.Mileage = inspection.Mileage;
            dbInspection.AirFilter = inspection.AirFilter;
            dbInspection.CabinFilter = inspection.CabinFilter;
            dbInspection.DriveBelt = inspection.DriveBelt;
            dbInspection.Exhaust = inspection.Exhaust;
            dbInspection.FrontBrakes = inspection.FrontBrakes;
            dbInspection.FrontHeadLights = inspection.FrontHeadLights;
            dbInspection.FrontRotors = inspection.FrontRotors;
            dbInspection.FrontSignals = inspection.FrontSignals;
            dbInspection.FrontSuspension = inspection.FrontSuspension;
            dbInspection.FrontTires = inspection.FrontTires;
            dbInspection.FrontWheels = inspection.FrontWheels;
            dbInspection.Horn = inspection.Horn;
            dbInspection.RearBrakes = inspection.RearBrakes;
            dbInspection.RearRotors = inspection.RearRotors;
            dbInspection.RearStopLights = inspection.RearStopLights;
            dbInspection.RearSuspension = inspection.RearSuspension;
            dbInspection.RearTires = inspection.RearTires;
            dbInspection.RearWheels = inspection.RearWheels;
            dbInspection.Steering = inspection.Steering;
            dbInspection.Wipers = inspection.Wipers;
            _inspectionRepo.EditInspection();

        }
        public void DeleteInspection(InspectionDTO Inspection)
        {
            _inspectionRepo.DeleteInspection(_inspectionRepo.GetInspectionById(Inspection.Id).First());
        }
    }
    
}
