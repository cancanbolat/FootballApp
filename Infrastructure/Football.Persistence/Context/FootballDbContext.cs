using Football.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Infrastructure.Persistence.Context
{
    public class FootballDbContext : DbContext
    {
        public FootballDbContext(DbContextOptions<FootballDbContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                //Table Name
                e.ToTable("users", "public");

                //Id
                e.HasKey(i => i.Id).HasName("pk_user_id");
                e.Property(i => i.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("UUID_GENERATE_V4()").IsRequired();

                //FirstName
                e.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("character varying").HasMaxLength(150);

                //LastName
                e.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("character varying").HasMaxLength(150);

                //UserName
                e.Property(i => i.UserName).HasColumnName("username").HasColumnType("character varying").HasMaxLength(20);

                //Email
                e.Property(i => i.Email).HasColumnName("email").HasColumnType("character varying").HasMaxLength(100);

                //Password
                e.Property(i => i.Password).HasColumnName("password").HasColumnType("character varying").HasMaxLength(20);

                //CreateDate
                e.Property(i => i.CreateDate).HasColumnName("create_date").HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");
            });

            modelBuilder.Entity<Player>(e =>
            {
                //Table Name
                e.ToTable("players", "public");

                //Id
                e.HasKey(i => i.Id).HasName("pk_player_id");
                e.Property(i => i.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("UUID_GENERATE_V4()").IsRequired();

                //FirstName
                e.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("character varying").HasMaxLength(150);

                //LastName
                e.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("character varying").HasMaxLength(150);

                //Photo
                e.Property(i => i.Photo).HasColumnName("photo").HasColumnType("character varying").HasMaxLength(250);

                //TeamId
                e.HasOne(h => h.Team)
                    .WithMany(w => w.Players)
                    .HasForeignKey(f => f.TeamId)
                    .HasConstraintName("pk_player_team_id")
                    .OnDelete(DeleteBehavior.Cascade);

                //PositionId
                e.HasOne(h => h.Positions)
                    .WithMany(w => w.Players)
                    .HasForeignKey(f => f.PositionId)
                    .HasConstraintName("pk_player_positin_id")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Team>(e =>
            {
                //Table Name
                e.ToTable("teams", "public");

                //Id
                e.HasKey(i => i.Id).HasName("pk_team_id");
                //e.Property(i => i.Id).HasColumnName("id").HasColumnType("smallserial").IsRequired();

                //Name
                e.Property(i => i.Name).HasColumnName("name").HasColumnType("character varying").HasMaxLength(150);

                //Logo
                e.Property(i => i.Logo).HasColumnName("logo").HasColumnType("character varying").HasMaxLength(150).HasDefaultValue("default_profile.png");
            });

            modelBuilder.Entity<Position>(e =>
            {

                //Table Name
                e.ToTable("positions", "public");

                //Id
                e.HasKey(i => i.Id).HasName("pk_position_id");
                //e.Property(i => i.Id).HasColumnName("id").HasColumnType("smallserial").IsRequired();

                //Name
                e.Property(i => i.Name).HasColumnName("name").HasColumnType("character varying").HasMaxLength(150);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
