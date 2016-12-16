using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EonnAuto.Services.ModelDTO
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public IList<InspectionDTO> Inspection { get; set; }
        public string VehiceUrl { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string EngSize { get; set; }
    }
}
