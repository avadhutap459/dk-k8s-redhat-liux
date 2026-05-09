using dk_k8s_redhat_liux.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace dk_k8s_redhat_liux.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
