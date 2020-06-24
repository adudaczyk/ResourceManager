﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResourceManager.EntityFrameworkCore;

namespace ResourceManager.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(ResourceManagerDbContext))]
    partial class ResourceManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ResourceManager.EntityFrameworkCore.Models.Reservation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAccepted");

                    b.Property<int>("ResourceItemId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Reservations","dbo");
                });

            modelBuilder.Entity("ResourceManager.EntityFrameworkCore.Models.Resource", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Resources","dbo");
                });

            modelBuilder.Entity("ResourceManager.EntityFrameworkCore.Models.ResourceItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ResourceId");

                    b.Property<long?>("ResourceId1");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId1");

                    b.ToTable("ResourceItems","dbo");
                });

            modelBuilder.Entity("ResourceManager.EntityFrameworkCore.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsEmailVerified");

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Users","dbo");
                });

            modelBuilder.Entity("ResourceManager.EntityFrameworkCore.Models.ResourceItem", b =>
                {
                    b.HasOne("ResourceManager.EntityFrameworkCore.Models.Resource")
                        .WithMany("ResourceItems")
                        .HasForeignKey("ResourceId1");
                });
#pragma warning restore 612, 618
        }
    }
}
