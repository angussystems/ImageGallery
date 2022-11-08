﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MRI.IdentityServer.DbContexts;

#nullable disable

namespace MRI.IdentityServer.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    partial class IdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MRI.IdentityServer.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Subject")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Active = true,
                            ConcurrencyStamp = "61f4580e-9905-4c87-9d97-53c46d9b61c8",
                            Password = "password",
                            Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                            UserName = "tom"
                        },
                        new
                        {
                            Id = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Active = true,
                            ConcurrencyStamp = "95223194-c4c6-4794-87d9-d116caffb520",
                            Password = "password",
                            Subject = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                            UserName = "emma"
                        });
                });

            modelBuilder.Entity("MRI.IdentityServer.Entities.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");

                    b.HasData(
                        new
                        {
                            Id = new Guid("263e3a96-a7ee-46ee-a523-0f9babd3d917"),
                            ConcurrencyStamp = "bcaf8a4a-7481-445a-bf8b-9616a8f35f7f",
                            Type = "given_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Tom"
                        },
                        new
                        {
                            Id = new Guid("2181ef66-8e63-47df-95c6-57045d6c7937"),
                            ConcurrencyStamp = "4418ebd6-a1d6-4f65-a5d1-efe66f934eda",
                            Type = "family_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Hanks"
                        },
                        new
                        {
                            Id = new Guid("2383795a-d5de-4550-9578-adc5ef396a4e"),
                            ConcurrencyStamp = "d9bc8f69-e899-4e96-93b6-79ef4abb1ce3",
                            Type = "country",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "canada"
                        },
                        new
                        {
                            Id = new Guid("54b7f9cd-d102-4e57-99f6-16f20dc96e0c"),
                            ConcurrencyStamp = "8793b53a-d3ba-476c-a617-e489d270d95e",
                            Type = "role",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "FreeUser"
                        },
                        new
                        {
                            Id = new Guid("aafb34f1-c7af-4c00-ae8f-90b199271fa9"),
                            ConcurrencyStamp = "50d7ae64-3596-43fd-af54-7d583a4ed05b",
                            Type = "given_name",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Emma"
                        },
                        new
                        {
                            Id = new Guid("8f7ffb63-96bf-4451-a6a7-3e6ce8b7b9d2"),
                            ConcurrencyStamp = "dc14163f-5227-4c25-a054-68f7ffc3600a",
                            Type = "family_name",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Flagg"
                        },
                        new
                        {
                            Id = new Guid("4c48385e-15e8-4d39-8860-670f5cf4a41e"),
                            ConcurrencyStamp = "acc383a8-a5a6-408f-9e54-bc3a14047058",
                            Type = "country",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "USA"
                        },
                        new
                        {
                            Id = new Guid("cfbaa436-b624-415c-9dc6-b666f7ff7724"),
                            ConcurrencyStamp = "cab28055-7b15-4a26-b964-5d06a868f4d9",
                            Type = "role",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "PayingUser"
                        });
                });

            modelBuilder.Entity("MRI.IdentityServer.Entities.UserClaim", b =>
                {
                    b.HasOne("MRI.IdentityServer.Entities.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MRI.IdentityServer.Entities.User", b =>
                {
                    b.Navigation("Claims");
                });
#pragma warning restore 612, 618
        }
    }
}
