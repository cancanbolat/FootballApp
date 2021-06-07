﻿// <auto-generated />
using System;
using Football.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Football.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(FootballDbContext))]
    [Migration("20210527125338_addUserTable")]
    partial class addUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BlazorFootball.Data.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("UUID_GENERATE_V4()");

                    b.Property<string>("FirstName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying")
                        .HasColumnName("last_name");

                    b.Property<string>("Photo")
                        .HasMaxLength(250)
                        .HasColumnType("character varying")
                        .HasColumnName("photo");

                    b.Property<int>("PositionId")
                        .HasColumnType("integer");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_player_id");

                    b.HasIndex("PositionId");

                    b.HasIndex("TeamId");

                    b.ToTable("players", "public");
                });

            modelBuilder.Entity("BlazorFootball.Data.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_position_id");

                    b.ToTable("positions", "public");
                });

            modelBuilder.Entity("BlazorFootball.Data.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Logo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(150)
                        .HasColumnType("character varying")
                        .HasDefaultValue("default_profile.png")
                        .HasColumnName("logo");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_team_id");

                    b.ToTable("teams", "public");
                });

            modelBuilder.Entity("BlazorFootball.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("UUID_GENERATE_V4()");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .HasColumnType("character varying")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .HasMaxLength(20)
                        .HasColumnType("character varying")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_user_id");

                    b.ToTable("users", "public");
                });

            modelBuilder.Entity("BlazorFootball.Data.Models.Player", b =>
                {
                    b.HasOne("BlazorFootball.Data.Models.Position", "Positions")
                        .WithMany("Players")
                        .HasForeignKey("PositionId")
                        .HasConstraintName("pk_player_positin_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorFootball.Data.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("pk_player_team_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Positions");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("BlazorFootball.Data.Models.Position", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("BlazorFootball.Data.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}