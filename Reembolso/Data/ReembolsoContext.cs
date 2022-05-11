using Microsoft.EntityFrameworkCore;
using Reembolso.Models;

namespace MtgDataAPI.Data

{
    public class ReembolsoContext : DbContext
    {
        public ReembolsoContext(DbContextOptions<ReembolsoContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Navigation(u => u.refounds).AutoInclude();
            //modelBuilder.Entity<User>().Navigation(u => u.subordinates).AutoInclude();
            modelBuilder.Entity<Refund>().Navigation(r => r.items).AutoInclude();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Refund> Refunds{ get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Department> departments { get; set; }

    }
}
