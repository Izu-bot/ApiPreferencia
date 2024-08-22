using ApiPreferencia.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace ApiPreferencia.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<LabelModel> Labels { get; set; }
        public virtual DbSet<PreferenceModel> Preferences { get; set; }
        public virtual DbSet<EmailLabel> EmailLabels { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected DatabaseContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserEmail).HasColumnName("User_email").IsRequired();
                entity.Property(e => e.PasswordHash).HasColumnName("Password").IsRequired();

                entity.HasMany(user => user.Labels)
                .WithOne(label => label.User)
                .HasForeignKey(label => label.UserId);

            });

            modelBuilder.Entity<LabelModel>(entity => 
            {
                entity.ToTable("Label");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<PreferenceModel>(entity =>
            {
                entity.ToTable("Preference");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Theme);
            });

            modelBuilder.Entity<PreferenceModel>()
                .HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<PreferenceModel>(e => e.UserId);

            modelBuilder.Entity<EmailLabel>(entity =>
            {
                entity.HasKey(el => new { el.EmailId, el.LabelId });
            });

            modelBuilder.Entity<EmailLabel>()
                .HasOne(el => el.Email)
                .WithMany(e => e.EmailLabels)
                .HasForeignKey(el => el.EmailId);
            
            modelBuilder.Entity<EmailLabel>()
                .HasOne(el => el.Label)
                .WithMany(l => l.EmailLabels)
                .HasForeignKey(el => el.LabelId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
