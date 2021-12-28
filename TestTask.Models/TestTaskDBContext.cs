using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public class TestTaskDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public TestTaskDBContext(DbContextOptions<TestTaskDBContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
