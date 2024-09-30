﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RandomCoffee.DAL.Data;

#nullable disable

namespace RandomCoffee.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240919082609_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RandomCoffee.DAL.Models.Coffee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Coffee");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Meeting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsSuccessful")
                        .HasColumnType("boolean");

                    b.Property<int?>("MeetingDuration")
                        .HasColumnType("integer");

                    b.Property<Guid?>("MeetingRoomMeetingId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MeetingRoomMeetingId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.MeetingDuration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("MeetingDurations");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.MeetingRoom", b =>
                {
                    b.Property<Guid>("MeetingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MeetingId");

                    b.ToTable("MeetingRooms");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdminLogin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("AutoPeriods")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecretKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("MeetingsEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OrganizationID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("QueueEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("QueueStart")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<Guid>("MeetingId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Queue", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId");

                    b.ToTable("Queues");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Submit", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsSubmited")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("MeetingDurationId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId");

                    b.HasIndex("MeetingDurationId");

                    b.ToTable("Submits");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CoffeeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pets")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uuid");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telegram")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Vk")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CoffeeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("PostId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.UserMeeting", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MeetingId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "MeetingId");

                    b.HasIndex("MeetingId");

                    b.ToTable("UsersMeetings");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.UserPhoto", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PhotoId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "PhotoId");

                    b.HasIndex("PhotoId");

                    b.ToTable("UsersPhoto");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Meeting", b =>
                {
                    b.HasOne("RandomCoffee.DAL.Models.MeetingRoom", "MeetingRoom")
                        .WithMany()
                        .HasForeignKey("MeetingRoomMeetingId");

                    b.Navigation("MeetingRoom");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.MeetingDuration", b =>
                {
                    b.HasOne("RandomCoffee.DAL.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Photo", b =>
                {
                    b.HasOne("RandomCoffee.DAL.Models.Meeting", null)
                        .WithMany("Photo")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Queue", b =>
                {
                    b.HasOne("RandomCoffee.DAL.Models.User", "User")
                        .WithOne("Queue")
                        .HasForeignKey("RandomCoffee.DAL.Models.Queue", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Submit", b =>
                {
                    b.HasOne("RandomCoffee.DAL.Models.MeetingDuration", "MeetingDuration")
                        .WithMany("Submits")
                        .HasForeignKey("MeetingDurationId");

                    b.HasOne("RandomCoffee.DAL.Models.User", "User")
                        .WithOne("Submit")
                        .HasForeignKey("RandomCoffee.DAL.Models.Submit", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeetingDuration");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.User", b =>
                {
                    b.HasOne("RandomCoffee.DAL.Models.Coffee", "Coffee")
                        .WithMany("Users")
                        .HasForeignKey("CoffeeId");

                    b.HasOne("RandomCoffee.DAL.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("RandomCoffee.DAL.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RandomCoffee.DAL.Models.Post", "Post")
                        .WithMany("Users")
                        .HasForeignKey("PostId");

                    b.Navigation("Coffee");

                    b.Navigation("Department");

                    b.Navigation("Organization");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.UserMeeting", b =>
                {
                    b.HasOne("RandomCoffee.DAL.Models.Meeting", "Meeting")
                        .WithMany("UsersMeetings")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RandomCoffee.DAL.Models.User", "User")
                        .WithMany("UsersMeetings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meeting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.UserPhoto", b =>
                {
                    b.HasOne("RandomCoffee.DAL.Models.Photo", "Photo")
                        .WithMany("UsersPhoto")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RandomCoffee.DAL.Models.User", "User")
                        .WithMany("UsersPhoto")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Coffee", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Meeting", b =>
                {
                    b.Navigation("Photo");

                    b.Navigation("UsersMeetings");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.MeetingDuration", b =>
                {
                    b.Navigation("Submits");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Photo", b =>
                {
                    b.Navigation("UsersPhoto");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.Post", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("RandomCoffee.DAL.Models.User", b =>
                {
                    b.Navigation("Queue")
                        .IsRequired();

                    b.Navigation("Submit");

                    b.Navigation("UsersMeetings");

                    b.Navigation("UsersPhoto");
                });
#pragma warning restore 612, 618
        }
    }
}
