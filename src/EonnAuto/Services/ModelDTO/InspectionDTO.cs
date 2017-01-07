using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EonnAuto.Services.ModelDTO
{
    public class InspectionDTO
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        public int Mileage { get; set; }

        //new inspections updates for group project,
        public string FrontBrakes { get; set; }
        public string FrontRotors { get; set; }
        public string FrontTires { get; set; }
        public string FrontHeadLights { get; set; }
        public string FrontSignals { get; set; }
        public string FrontWheels { get; set; }
        public string FrontSuspension { get; set; }
        public string RearBrakes { get; set; }
        public string RearRotors { get; set; }
        public string RearTires { get; set; }
        public string RearWheels { get; set; }
        public string RearStopLights { get; set; }
        public string RearSuspension { get; set; }
        public string Exhaust { get; set; }
        public string Steering { get; set; }
        public string DriveBelt { get; set; }
        public string Horn { get; set; }
        public string Wipers { get; set; }
        public string AirFilter { get; set; }
        public string CabinFilter { get; set; }
    }
}
