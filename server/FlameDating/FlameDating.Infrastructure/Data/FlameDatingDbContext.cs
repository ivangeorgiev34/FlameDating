using FlameDating.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlameDating.Infrastructure.Data
{
    public class FlameDatingDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public FlameDatingDbContext(DbContextOptions<FlameDatingDbContext> options) : base(options)
        {
        }

        protected FlameDatingDbContext()
        {
        }

        public DbSet<Preference>? Preferences { get; set; }

        public DbSet<Message>? Messages { get; set; }

        public DbSet<Match>? Matches { get; set; }

        public DbSet<Like>? Likes { get; set; }

        public DbSet<Interest>? Interests { get; set; }

        public DbSet<Chat>? Chats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Like>()
                .HasOne(l => l.Liker)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.LikerUserId)
                .IsRequired();

            builder.Entity<Match>()
                .HasOne(m => m.FirstUser)
                .WithMany(u => u.Matches)
                .HasForeignKey(l => l.FirstUserId)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.LocationLongitude)
                .HasPrecision(18, 7);

            builder.Entity<User>()
                .Property(u => u.LocationLatitude)
                .HasPrecision(18, 7);

            SeedInterests(builder);

            base.OnModelCreating(builder);
        }

        private void SeedInterests(ModelBuilder builder)
        {
            builder.Entity<Interest>()
                .HasData(
                new Interest()
                {
                    Id = new Guid("eae75d50-9d66-4cfb-a5db-7876631c3efa"),
                    Name = "Football"
                },
                new Interest()
                {
                    Id = new Guid("199feb67-3bb8-467f-bdfd-11986cb997cd"),
                    Name = "Basketball"
                },
                new Interest()
                {
                    Id = new Guid("05bc65cd-9894-41f0-9a74-b33d1f637fa1"),
                    Name = "Volleyball"
                },
                new Interest()
                {
                    Id = new Guid("d0575979-2d72-417b-b3b7-a4add16c8b58"),
                    Name = "Handball"
                },
                new Interest()
                {
                    Id = new Guid("a562cf54-0a25-4b82-91b8-318520bbf00c"),
                    Name = "Yoga"
                },
                new Interest()
                {
                    Id = new Guid("1594ef2b-dd88-4718-9b66-91d77ce2e38e"),
                    Name = "Skiing"
                },
                new Interest()
                {
                    Id = new Guid("475b65f8-9bc3-4122-b477-824b936769a1"),
                    Name = "Hiking"
                },
                new Interest()
                {
                    Id = new Guid("f0a08a9f-7afc-42a2-ba5f-24aba7a4c16f"),
                    Name = "Cars"
                },
                new Interest()
                {
                    Id = new Guid("ad1a8096-0384-48eb-aef6-0dcc1d1f5ac6"),
                    Name = "Boxing"
                },
                new Interest()
                {
                    Id = new Guid("5fb8e6f1-40b6-4d63-9b39-3f4fb86243c3"),
                    Name = "Running"
                },
                new Interest()
                {
                    Id = new Guid("26b2ac03-9a93-45c0-8c93-2a97ab68d6db"),
                    Name = "Singing"
                },
                new Interest()
                {
                    Id = new Guid("e6d97faf-14c7-45c5-bf28-b5dd6e791300"),
                    Name = "Martial Arts"
                },
                new Interest()
                {
                    Id = new Guid("12aa84d4-1fa9-4725-9acc-25e05b59ab38"),
                    Name = "Fishing"
                },
                new Interest()
                {
                    Id = new Guid("6d9a0e5d-6c79-442c-b150-9ca1b9b9f80c"),
                    Name = "Swimming"
                },
                new Interest()
                {
                    Id = new Guid("2effc604-2024-4c03-b7c3-9376804afb70"),
                    Name = "Cycling"
                },
                new Interest()
                {
                    Id = new Guid("0ae4b0ad-c36b-41bd-9e25-af6b7d206ded"),
                    Name = "Reading"
                });
        }
    }
}
