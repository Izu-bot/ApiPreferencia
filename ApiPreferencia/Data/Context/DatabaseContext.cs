using ApiPreferencia.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiPreferencia.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<LabelModel> Labels { get; set; }
        public virtual DbSet<PreferenceModel> Preferences { get; set; }

        protected DatabaseContext(DbContextOptions options) : base(options) { }

        protected DatabaseContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
