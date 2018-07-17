using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lab8.Models
{
    public class AirportDB : DbContext
    {
        public AirportDB() : base("DefaultConnection")
        {

        }
        public DbSet<Plane> Planes { get; set; }
    }
}
