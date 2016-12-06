using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EonnAuto.Services.ModelDTO
{
    public class InspectionDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Mileage { get; set; }
        public string Brake { get; set; }
        public string Rotor { get; set; }
        public string Tire { get; set; }
        public string Shock { get; set; }
    }
}
