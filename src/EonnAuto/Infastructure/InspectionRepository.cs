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
        public IQueryable<Inspection> GetInspectionForvehicle(int vehicleId)
        {
            return from i in _db.Inspections
                   where i.VehicleId == vehicleId
                   select i;          
        }
        public void Add(Inspection inspection)
        {
            _db.Inspections.Add(inspection);
            _db.SaveChanges();
        }
        public void DeleInspection(Inspection dbInspection, int id)
        {
            _db.Inspections.Remove(dbInspection);
            _db.SaveChanges();
        }
    }
}
