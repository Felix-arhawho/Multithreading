using MultiThreadingDemo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingDemo.Domain.Context
{
    public class MultiThreadingDemoContext : DbContext
    {
        public MultiThreadingDemoContext() : base("MultiThreadingDemo")
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
    }
}