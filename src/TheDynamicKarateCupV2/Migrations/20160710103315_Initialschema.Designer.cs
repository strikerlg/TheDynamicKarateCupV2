using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TheDynamicKarateCupV2.Models;

namespace TheDynamicKarateCupV2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160710103315_Initialschema")]
    partial class Initialschema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discipline");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.Club", b =>
                {
                    b.Property<int>("ClubID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClubName")
                        .IsRequired();

                    b.Property<string>("ClubNumber")
                        .IsRequired();

                    b.Property<string>("ResponsibleCellullar")
                        .IsRequired();

                    b.Property<string>("ResponsibleEmail")
                        .IsRequired();

                    b.Property<string>("ResponsibleName")
                        .IsRequired();

                    b.HasKey("ClubID");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.Coach", b =>
                {
                    b.Property<int>("CoachID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClubID");

                    b.Property<string>("CoachFirstName")
                        .IsRequired();

                    b.Property<string>("CoachName")
                        .IsRequired();

                    b.Property<string>("LicenseNumber")
                        .IsRequired();

                    b.HasKey("CoachID");

                    b.HasIndex("ClubID");

                    b.ToTable("Coach");
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.Competitor", b =>
                {
                    b.Property<int>("CompetitorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AgeCategory")
                        .IsRequired();

                    b.Property<int>("ClubID");

                    b.Property<string>("CompetitorFirstname")
                        .IsRequired();

                    b.Property<string>("CompetitorName")
                        .IsRequired();

                    b.Property<string>("Disciplines")
                        .IsRequired();

                    b.Property<string>("Level")
                        .IsRequired();

                    b.Property<string>("LicenseNumber")
                        .IsRequired();

                    b.Property<string>("Sex")
                        .IsRequired();

                    b.HasKey("CompetitorID");

                    b.HasIndex("ClubID");

                    b.ToTable("Competitor");
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.CompetitorCategory", b =>
                {
                    b.Property<int>("CompetitorID");

                    b.Property<int>("CategoryID");

                    b.HasKey("CompetitorID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("CompetitorID");

                    b.ToTable("CompetitorCategory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TheDynamicKarateCupV2.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TheDynamicKarateCupV2.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TheDynamicKarateCupV2.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.Coach", b =>
                {
                    b.HasOne("TheDynamicKarateCupV2.Models.Club", "Club")
                        .WithMany("Coaches")
                        .HasForeignKey("ClubID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.Competitor", b =>
                {
                    b.HasOne("TheDynamicKarateCupV2.Models.Club", "Club")
                        .WithMany("Competitors")
                        .HasForeignKey("ClubID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.CompetitorCategory", b =>
                {
                    b.HasOne("TheDynamicKarateCupV2.Models.Category", "Category")
                        .WithMany("CompetitorCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TheDynamicKarateCupV2.Models.Competitor", "Competitor")
                        .WithMany("CompetitorCategories")
                        .HasForeignKey("CompetitorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
