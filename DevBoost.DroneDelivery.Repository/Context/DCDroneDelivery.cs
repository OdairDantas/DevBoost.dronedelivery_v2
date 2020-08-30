using DevBoost.dronedelivery.Domain;
using DevBoost.DroneDelivery.Domain.Entities;
using DevBoost.DroneDelivery.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Threading.Tasks;

namespace DevBoost.DroneDelivery.Repository.Context
{
    public class DCDroneDelivery : DbContext, IUnitOfWork
    {
        public DCDroneDelivery(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DroneDelivery;Trusted_Connection=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Cliente>().HasOne(c => c.User).WithOne(u => u.Cliente).HasForeignKey<Usuario>(u => u.ClienteId);
           
            modelBuilder.Entity<Pedido>().HasOne(p => p.Cliente).WithMany(c => c.Pedido);

            base.OnModelCreating(modelBuilder); 

        }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Drone> Drone { get; set; }
        public DbSet<DroneItinerario> DroneItinerario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; } 
        public async Task<bool> Commit()
        {
            try
            {
                var sucesso = await base.SaveChangesAsync() > 0;
                return sucesso;
            }
            catch (System.Exception ex)
            {

                return await (Task.Run(()=>false));
            }
            
        }
    }
}
