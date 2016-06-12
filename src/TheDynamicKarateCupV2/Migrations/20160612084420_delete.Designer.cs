using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TheDynamicKarateCupV2.Models;

namespace TheDynamicKarateCupV2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160612084420_delete")]
    partial class delete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
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
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
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
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discipline");

                    b.HasKey("CategoryID");
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
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.Coach", b =>
                {
                    b.Property<int>("CoachID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClubID");

                    b.Property<string>("CoachFirstName")
                        .IsRequired();

                    b.Property<string>("CoachFirstNameName");

                    b.Property<string>("CoachName")
                        .IsRequired();

                    b.HasKey("CoachID");
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
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.CompetitorCategory", b =>
                {
                    b.Property<int>("CompetitorID");

                    b.Property<int>("CategoryID");

                    b.HasKey("CompetitorID", "CategoryID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TheDynamicKarateCupV2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TheDynamicKarateCupV2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("TheDynamicKarateCupV2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.Coach", b =>
                {
                    b.HasOne("TheDynamicKarateCupV2.Models.Club")
                        .WithMany()
                        .HasForeignKey("ClubID");
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.Competitor", b =>
                {
                    b.HasOne("TheDynamicKarateCupV2.Models.Club")
                        .WithMany()
                        .HasForeignKey("ClubID");
                });

            modelBuilder.Entity("TheDynamicKarateCupV2.Models.CompetitorCategory", b =>
                {
                    b.HasOne("TheDynamicKarateCupV2.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("TheDynamicKarateCupV2.Models.Competitor")
                        .WithMany()
                        .HasForeignKey("CompetitorID");
                });
        }
    }
}
