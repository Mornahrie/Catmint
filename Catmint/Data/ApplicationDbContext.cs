using Catmint.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Catmint.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Right> Rights { get; set; }
        public virtual DbSet<Sex> Sexs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<Booked> Bookeds { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Menu> Dishes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Lazalka> Lazalki { get; set; }
    }
}



