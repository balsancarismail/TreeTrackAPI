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
    [Migration("20230109164658_UserGardenRelationTable")]
    partial class UserGardenRelationTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.Garden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Area")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

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

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GardenId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GardenId");

                    b.HasIndex("PlantId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("GardenId")
                        .HasColumnType("int");

                    b.Property<Point>("Location")
                        .HasColumnType("geography");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlantTypeId")
                        .IsRequired()
                        .HasColumnType("int");

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

                    b.Property<string>("Subtype")
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

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.UserGarden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GardenId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GardenId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGardens");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.Note", b =>
                {
                    b.HasOne("TreeTrackAPI.Domain.concretes.Garden", null)
                        .WithMany("Notes")
                        .HasForeignKey("GardenId");

                    b.HasOne("TreeTrackAPI.Domain.concretes.Plant", "Plant")
                        .WithMany("Notes")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
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

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.UserGarden", b =>
                {
                    b.HasOne("TreeTrackAPI.Domain.concretes.Garden", "Garden")
                        .WithMany("Users")
                        .HasForeignKey("GardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreeTrackAPI.Domain.concretes.User", "User")
                        .WithMany("Gardens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garden");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.Garden", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("Plants");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.Plant", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.PlantType", b =>
                {
                    b.Navigation("Plants");
                });

            modelBuilder.Entity("TreeTrackAPI.Domain.concretes.User", b =>
                {
                    b.Navigation("Gardens");
                });
#pragma warning restore 612, 618
        }
    }
}
