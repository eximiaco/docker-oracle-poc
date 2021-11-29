using docker_oracle_poc.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace docker_oracle_poc.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        
        public DbSet<Certificate> Certificates { get; set; }
    }
}