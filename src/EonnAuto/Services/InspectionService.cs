using EonnAuto.Infastructure;
using EonnAuto.Services.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EonnAuto.Services
{
    public class InspectionService
    {
        private InspectionRepository _inspectionRep;
        private VehicleRepository _vehicleRepo;

        public InspectionService(InspectionRepository ir, VehicleRepository vr)
        {
            _inspectionRep = ir;
            _vehicleRepo = vr;
        }
        public IList<InspectionDTO> GetInspectionForVehicle(int Id)
        {
            return (from i in _inspectionRep.GetInspectionForvehicle(Id)
                    select new InspectionDTO()
                    {
                        Id = i.Id,
                        Date = i.Date,
                        Mileage = i.Mileage,
                        Brake = i.Brake,
                        Rotor = i.Rotor,
                        Tire = i.Tire,
                        Shock = i.Shock,
                    }).ToList();
        }
    }
}
