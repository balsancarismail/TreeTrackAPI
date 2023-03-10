// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using TreeTrackAPI.DataAccessLayer.concretes.efcore;

#nullable disable

namespace TreeTrackAPI.DataAccessLayer.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20221226161157_updateCheck")]
    partial class updateCheck
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GardenUser", b =>
                {
                    b.Property<int>("GardensId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("GardensId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GardenUser");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.Garden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Area")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GardenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Polygon>("Polygon")
                        .HasColumnType("geography");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Gardens");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GardenId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("PlantId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GardenId");

                    b.HasIndex("PlantId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("GardenId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlantTypeId")
                        .HasColumnType("int");

                    b.Property<Point>("Point")
                        .HasColumnType("geography");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GardenId");

                    b.HasIndex("PlantTypeId");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.PlantType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlantTypes");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GardenUser", b =>
                {
                    b.HasOne("TreeTrackAPI.Domain.concretes.Garden", null)
                        .WithMany()
                        .HasForeignKey("GardensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreeTrackAPI.Domain.concretes.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.Note", b =>
                {
                    b.HasOne("TreeTrackAPI.Domain.concretes.Garden", null)
                        .WithMany("Notes")
                        .HasForeignKey("GardenId");

                    b.HasOne("TreeTrackAPI.Domain.concretes.Plant", null)
                        .WithMany("Notes")
                        .HasForeignKey("PlantId");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.Plant", b =>
                {
                    b.HasOne("TreeTrackAPI.Domain.concretes.Garden", "Garden")
                        .WithMany("Plants")
                        .HasForeignKey("GardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreeTrackAPI.Domain.concretes.PlantType", "PlantType")
                        .WithMany("Plants")
                        .HasForeignKey("PlantTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garden");

                    b.Navigation("PlantType");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.Garden", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("Plants");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.Plant", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.PlantType", b =>
                {
                    b.Navigation("Plants");
                });
#pragma warning restore 612, 618
        }
    }
}
