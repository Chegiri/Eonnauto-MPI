using EonnAuto.Data;
using EonnAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EonnAuto.Infastructure
{
    public class UserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IQueryable<ApplicationUser> GetUser(string userName)
        {
            return from u in _db.Users
                   where u.UserName == userName
                   select u;
        }
    }
}
