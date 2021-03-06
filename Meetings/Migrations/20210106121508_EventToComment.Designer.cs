﻿// <auto-generated />
using System;
using Meetings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Meetings.Migrations
{
    [DbContext(typeof(MeetingDBContext))]
    [Migration("20210106121508_EventToComment")]
    partial class EventToComment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Meetings.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Meetings.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Meetings.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Meetings.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<byte[]>("ProfPicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("Meetings.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Kebab")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Meetings.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool?>("IsActive")
                        .HasColumnName("Is_Active")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsBanned")
                        .HasColumnName("Is_Banned")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(12)")
                        .HasMaxLength(12)
                        .IsUnicode(false);

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Meetings.Models.Comment", b =>
                {
                    b.HasOne("Meetings.Models.Event", "Event")
                        .WithMany("Comments")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_Comment_ToEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Meetings.Models.Profile", b =>
                {
                    b.HasOne("Meetings.Models.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Meetings.Models.Profile", "UserId")
                        .HasConstraintName("FK_Profile_ToUser");
                });
#pragma warning restore 612, 618
        }
    }
}
