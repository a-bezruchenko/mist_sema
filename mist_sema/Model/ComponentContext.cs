using Microsoft.EntityFrameworkCore;
using mist_sema.DataClasses;

namespace mist_sema.Model
{
    public class ComponentContext : DbContext
    {
        public DbSet<ComputerComponent>? Components { get; set; }
        public DbSet<GraphicCard>? GraphicCards { get; set; }
        public DbSet<PowerSupply>? PowerSupplies { get; set; }
        public DbSet<Processor>? Processors { get; set; }
        public DbSet<Ram>? Rams { get; set; }
        public DbSet<StorageDevice>? StorageDevices { get; set; }
        public DbSet<SystemBoard>? SystemBoards { get; set; }

        public ComponentContext(DbContextOptions<ComponentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComputerComponent>().ToTable("components");
            modelBuilder.Entity<GraphicCard>().ToTable("graphicCards");
            modelBuilder.Entity<PowerSupply>().ToTable("powerSupplies");
            modelBuilder.Entity<Processor>().ToTable("processors");
            modelBuilder.Entity<Ram>().ToTable("rams");
            modelBuilder.Entity<StorageDevice>().ToTable("storageDevices");
            modelBuilder.Entity<SystemBoard>().ToTable("systemBoards");
        }
    }
}
