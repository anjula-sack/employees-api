using employees.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace employees.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext() : base()
    {
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}