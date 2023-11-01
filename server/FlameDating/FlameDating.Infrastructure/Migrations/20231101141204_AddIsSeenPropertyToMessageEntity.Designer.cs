﻿// <auto-generated />
using System;
using FlameDating.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlameDating.Infrastructure.Migrations
{
    [DbContext(typeof(FlameDatingDbContext))]
    [Migration("20231101141204_AddIsSeenPropertyToMessageEntity")]
    partial class AddIsSeenPropertyToMessageEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlameDating.Infrastructure.Models.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.Interest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eae75d50-9d66-4cfb-a5db-7876631c3efa"),
                            Name = "Football"
                        },
                        new
                        {
                            Id = new Guid("199feb67-3bb8-467f-bdfd-11986cb997cd"),
                            Name = "Basketball"
                        },
                        new
                        {
                            Id = new Guid("05bc65cd-9894-41f0-9a74-b33d1f637fa1"),
                            Name = "Volleyball"
                        },
                        new
                        {
                            Id = new Guid("d0575979-2d72-417b-b3b7-a4add16c8b58"),
                            Name = "Handball"
                        },
                        new
                        {
                            Id = new Guid("a562cf54-0a25-4b82-91b8-318520bbf00c"),
                            Name = "Yoga"
                        },
                        new
                        {
                            Id = new Guid("1594ef2b-dd88-4718-9b66-91d77ce2e38e"),
                            Name = "Skiing"
                        },
                        new
                        {
                            Id = new Guid("475b65f8-9bc3-4122-b477-824b936769a1"),
                            Name = "Hiking"
                        },
                        new
                        {
                            Id = new Guid("f0a08a9f-7afc-42a2-ba5f-24aba7a4c16f"),
                            Name = "Cars"
                        },
                        new
                        {
                            Id = new Guid("ad1a8096-0384-48eb-aef6-0dcc1d1f5ac6"),
                            Name = "Boxing"
                        },
                        new
                        {
                            Id = new Guid("5fb8e6f1-40b6-4d63-9b39-3f4fb86243c3"),
                            Name = "Running"
                        },
                        new
                        {
                            Id = new Guid("26b2ac03-9a93-45c0-8c93-2a97ab68d6db"),
                            Name = "Singing"
                        },
                        new
                        {
                            Id = new Guid("e6d97faf-14c7-45c5-bf28-b5dd6e791300"),
                            Name = "Martial Arts"
                        },
                        new
                        {
                            Id = new Guid("12aa84d4-1fa9-4725-9acc-25e05b59ab38"),
                            Name = "Fishing"
                        },
                        new
                        {
                            Id = new Guid("6d9a0e5d-6c79-442c-b150-9ca1b9b9f80c"),
                            Name = "Swimming"
                        },
                        new
                        {
                            Id = new Guid("2effc604-2024-4c03-b7c3-9376804afb70"),
                            Name = "Cycling"
                        },
                        new
                        {
                            Id = new Guid("0ae4b0ad-c36b-41bd-9e25-af6b7d206ded"),
                            Name = "Reading"
                        });
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LikeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LikeStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("LikedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LikerUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LikedUserId");

                    b.HasIndex("LikerUserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FirstUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SecondUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("FirstUserId");

                    b.HasIndex("SecondUserId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.Property<Guid>("RecieverUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SenderUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("RecieverUserId");

                    b.HasIndex("SenderUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.Preference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("MaximumDistance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("FifthProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FirstProfilePicture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("FourthProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LocationLatitude")
                        .HasPrecision(18, 7)
                        .HasColumnType("decimal(18,7)");

                    b.Property<decimal>("LocationLongitude")
                        .HasPrecision(18, 7)
                        .HasColumnType("decimal(18,7)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid>("PreferenceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("School")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("SecondProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ThirdProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PreferenceId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.Interest", b =>
                {
                    b.HasOne("FlameDating.Infrastructure.Models.User", null)
                        .WithMany("Interests")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.Like", b =>
                {
                    b.HasOne("FlameDating.Infrastructure.Models.User", "Liked")
                        .WithMany()
                        .HasForeignKey("LikedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlameDating.Infrastructure.Models.User", "Liker")
                        .WithMany("Likes")
                        .HasForeignKey("LikerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Liked");

                    b.Navigation("Liker");
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.Match", b =>
                {
                    b.HasOne("FlameDating.Infrastructure.Models.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlameDating.Infrastructure.Models.User", "FirstUser")
                        .WithMany("Matches")
                        .HasForeignKey("FirstUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlameDating.Infrastructure.Models.User", "SecondUser")
                        .WithMany()
                        .HasForeignKey("SecondUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("FirstUser");

                    b.Navigation("SecondUser");
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.Message", b =>
                {
                    b.HasOne("FlameDating.Infrastructure.Models.Chat", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatId");

                    b.HasOne("FlameDating.Infrastructure.Models.User", "Reciever")
                        .WithMany()
                        .HasForeignKey("RecieverUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlameDating.Infrastructure.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reciever");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.User", b =>
                {
                    b.HasOne("FlameDating.Infrastructure.Models.Preference", "Preference")
                        .WithMany()
                        .HasForeignKey("PreferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Preference");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("FlameDating.Infrastructure.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("FlameDating.Infrastructure.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlameDating.Infrastructure.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("FlameDating.Infrastructure.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("FlameDating.Infrastructure.Models.User", b =>
                {
                    b.Navigation("Interests");

                    b.Navigation("Likes");

                    b.Navigation("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}
