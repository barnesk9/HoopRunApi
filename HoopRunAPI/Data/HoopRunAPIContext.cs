using Microsoft.EntityFrameworkCore;
using HoopRunAPI.Models;

namespace HoopRunAPI.Models
{
    public class HoopRunAPIContext : DbContext
    {
        public HoopRunAPIContext (DbContextOptions<HoopRunAPIContext> options)
            : base(options)
        {
        }

        //public DbSet<UserModel> UserModel { get; set; }
        //public DbSet<Address> Address { get; set; }
        public DbSet<Gym> Gym { get; set; }
        public DbSet<GymOwner> GymOwner { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Run> Run { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerRun>()
                .HasKey(pr => new { pr.PlayerId, pr.RunId });
            modelBuilder.Entity<PlayerRun>()
                .HasOne(pl => pl.Player)
                .WithMany(p => p.PlayerRuns)
                .HasForeignKey(pr => pr.PlayerId);
            modelBuilder.Entity<PlayerRun>()
                .HasOne(r => r.Run)
                .WithMany(rp => rp.RunningPlayers)
                .HasForeignKey(pr => pr.RunId);
        }

        public DbSet<HoopRunAPI.Models.PlayerRun> PlayerRun { get; set; }
    }
}
