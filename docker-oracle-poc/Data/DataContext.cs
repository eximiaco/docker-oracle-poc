using docker_oracle_poc.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace docker_oracle_poc.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Certificate> Certificates { get; set; }
    }
}