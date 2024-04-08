using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //Agents will be the name of the table
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Area> Areas { get; set; }


    }
}
