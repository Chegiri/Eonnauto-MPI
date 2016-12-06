using EonnAuto.Data;
using EonnAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EonnAuto.Infastructure
{
    public class InspectionRepository
    {
        public ApplicationDbContext _db;
        
        public InspectionRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IQueryable<Inspection> GetInspectionFromvehicle(string vehicle)
        {
            return from i in _db.Inspections
                   
        }
        
    }
}
