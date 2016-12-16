using EonnAuto.Data;
using EonnAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EonnAuto.Infastructure
{
    public class VehicleRepository
    {
        public ApplicationDbContext _db;

        public VehicleRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IQueryable<Vehicle> GetVehicleForuser(string userName)
        {
            return from v in _db.Vehicles
                   where v.User.UserName == userName
                   select v;
        }
        public void Add(Vehicle vehicle)
        {
            _db.Vehicles.Add(vehicle);
            _db.SaveChanges();
        }
        public IQueryable<Vehicle> GetVehicleById(int id, string user)
        {
            return from v in _db.Vehicles
                   where v.Id == id && v.User.UserName == user
                   select v;
        }
        public void DeleVehicle(Vehicle dbVehicle, string user)
        {
            _db.Vehicles.Remove(dbVehicle);
            _db.SaveChanges();
        }
    }
}
