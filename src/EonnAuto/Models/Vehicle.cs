using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EonnAuto.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string UserId { get; set; } [ForeignKey("ApplicationUserId")]
        public ApplicationUser User { get; set; }

        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string EngSize { get; set; }

        public ICollection<Inspection> Inspection { get; set; }
    }
}
