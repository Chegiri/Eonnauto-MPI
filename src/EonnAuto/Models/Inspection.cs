using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EonnAuto.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        public int VehicleId { get; set; } [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        public DateTime Date { get; set; }
        public int Mileage { get; set; }
        public string Brake { get; set; }
        public string Rotor { get; set; }
        public string Tire { get; set; }
        public string Shock { get; set; }

    }
}
