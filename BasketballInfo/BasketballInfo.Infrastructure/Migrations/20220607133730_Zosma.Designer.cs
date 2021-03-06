// <auto-generated />
using System;
using BasketballInfo.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BasketballInfo.Infrastructure.Migrations
{
    [DbContext(typeof(BasketballInfoContext))]
    [Migration("20220607133730_Zosma")]
    partial class Zosma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BasketballInfo.Domain.Coach", b =>
                {
                    b.Property<int>("CoachId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsQualified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("CoachId");

                    b.HasIndex("TeamId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("BasketballInfo.Domain.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PlayerHeight")
                        .HasColumnType("float");

                    b.Property<double>("PlayerWeight")
                        .HasColumnType("float");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BasketballInfo.Domain.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            Name = "Los Angeles Lakers",
                            State = "Claifornia"
                        },
                        new
                        {
                            TeamId = 2,
                            Name = "Los Angeles Clippers",
                            State = "Claifornia"
                        },
                        new
                        {
                            TeamId = 3,
                            Name = "Golden State Warriors",
                            State = "Claifornia"
                        },
                        new
                        {
                            TeamId = 4,
                            Name = "Phoenix Suns",
                            State = "Arizona"
                        },
                        new
                        {
                            TeamId = 5,
                            Name = "Denvor Nuggets",
                            State = "Colorado"
                        },
                        new
                        {
                            TeamId = 6,
                            Name = "Miami Heat",
                            State = "Florida"
                        },
                        new
                        {
                            TeamId = 7,
                            Name = "Orlando Magic",
                            State = "Florida"
                        },
                        new
                        {
                            TeamId = 8,
                            Name = "Atlanta Hawks",
                            State = "Georgia"
                        },
                        new
                        {
                            TeamId = 9,
                            Name = "Chicago Bulls",
                            State = "Illinois"
                        },
                        new
                        {
                            TeamId = 10,
                            Name = "Boston Celtics",
                            State = "Massachusetts"
                        });
                });

            modelBuilder.Entity("BasketballInfo.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BasketballInfo.Domain.Coach", b =>
                {
                    b.HasOne("BasketballInfo.Domain.Team", "Team")
                        .WithMany("Coach")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("BasketballInfo.Domain.Player", b =>
                {
                    b.HasOne("BasketballInfo.Domain.Team", "Team")
                        .WithMany("Player")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("BasketballInfo.Domain.Team", b =>
                {
                    b.Navigation("Coach");

                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
