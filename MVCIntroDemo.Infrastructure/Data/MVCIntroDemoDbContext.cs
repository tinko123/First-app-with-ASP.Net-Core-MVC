using Microsoft.EntityFrameworkCore;
using MVCIntroDemo.Infrastructure.Data.Configuration;
using MVCIntroDemo.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCIntroDemo.Infrastructure.Data
{
    public class MVCIntroDemoDbContext : DbContext
    {
        public MVCIntroDemoDbContext(DbContextOptions<MVCIntroDemoDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Post> Posts { get; set; }
    }
}
