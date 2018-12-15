﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApp1.Models;

namespace WebApp1.Migrations
{
    [DbContext(typeof(WebshopContext))]
    [Migration("20181215154907_kaas")]
    partial class kaas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-preview1-35029")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebApp1.Models.Attribuutsoort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Attrbuut");

                    b.Property<bool>("Custom");

                    b.Property<int>("ProductsoortId");

                    b.Property<int?>("ProductwaardeId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ProductsoortId");

                    b.HasIndex("ProductwaardeId");

                    b.ToTable("Attribuutsoort");
                });

            modelBuilder.Entity("WebApp1.Models.Attribuutwaarde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AttribuutsoortId");

                    b.Property<int>("ProductwaardeId");

                    b.Property<string>("Waarde");

                    b.HasKey("Id");

                    b.HasIndex("AttribuutsoortId");

                    b.HasIndex("ProductwaardeId");

                    b.ToTable("Attribuutwaarde");
                });

            modelBuilder.Entity("WebApp1.Models.BesteldeItem", b =>
                {
                    b.Property<int>("BesteldeItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BestellingId");

                    b.Property<string>("Image");

                    b.Property<double>("Price");

                    b.Property<int>("ProductwaardeId");

                    b.Property<int>("Quantity");

                    b.Property<string>("Title");

                    b.HasKey("BesteldeItemId");

                    b.HasIndex("BestellingId");

                    b.ToTable("BesteldeItem");
                });

            modelBuilder.Entity("WebApp1.Models.Bestelling", b =>
                {
                    b.Property<int>("BestellingId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Status");

                    b.Property<string>("UserId");

                    b.HasKey("BestellingId");

                    b.HasIndex("UserId");

                    b.ToTable("Bestelling");
                });

            modelBuilder.Entity("WebApp1.Models.Extra_Atributes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Atribute");

                    b.Property<int>("ProductsId");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.ToTable("Extra_Atributes");
                });

            modelBuilder.Entity("WebApp1.Models.FavoritesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<int>("ProductId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("WebApp1.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WebApp1.Models.ParentChild", b =>
                {
                    b.Property<int>("ChildId");

                    b.Property<int>("ParentId");

                    b.HasKey("ChildId", "ParentId");

                    b.HasIndex("ParentId");

                    b.ToTable("ParentChild");
                });

            modelBuilder.Entity("WebApp1.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Price");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApp1.Models.Productsoort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.Property<bool>("RootParent");

                    b.HasKey("Id");

                    b.ToTable("Productsoort");
                });

            modelBuilder.Entity("WebApp1.Models.Productwaarde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<double>("DiscountedPrice");

                    b.Property<string>("Image");

                    b.Property<double>("Price");

                    b.Property<int>("ProductsoortId");

                    b.Property<int>("Quantity");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ProductsoortId");

                    b.ToTable("Productwaarde");
                });

            modelBuilder.Entity("WebApp1.Models.Users", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApp1.Models.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApp1.Models.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp1.Models.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApp1.Models.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp1.Models.Attribuutsoort", b =>
                {
                    b.HasOne("WebApp1.Models.Productsoort", "productsoort")
                        .WithMany("Attribuutsoort")
                        .HasForeignKey("ProductsoortId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp1.Models.Productwaarde")
                        .WithMany("Attribuutsoorts")
                        .HasForeignKey("ProductwaardeId");
                });

            modelBuilder.Entity("WebApp1.Models.Attribuutwaarde", b =>
                {
                    b.HasOne("WebApp1.Models.Attribuutsoort", "attribuutsoort")
                        .WithMany("Attribuutwaarde")
                        .HasForeignKey("AttribuutsoortId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp1.Models.Productwaarde", "productwaarde")
                        .WithMany("Attribuutwaarde")
                        .HasForeignKey("ProductwaardeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp1.Models.BesteldeItem", b =>
                {
                    b.HasOne("WebApp1.Models.Bestelling", "Bestelling")
                        .WithMany("BesteldeItem")
                        .HasForeignKey("BestellingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp1.Models.Bestelling", b =>
                {
                    b.HasOne("WebApp1.Models.Users", "User")
                        .WithMany("Bestelling")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebApp1.Models.Extra_Atributes", b =>
                {
                    b.HasOne("WebApp1.Models.Products", "products")
                        .WithMany("Extra_Atributes")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp1.Models.FavoritesModel", b =>
                {
                    b.HasOne("WebApp1.Models.Productwaarde", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp1.Models.Item", b =>
                {
                    b.HasOne("WebApp1.Models.Productwaarde", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("WebApp1.Models.ParentChild", b =>
                {
                    b.HasOne("WebApp1.Models.Productsoort", "Child")
                        .WithMany("Children")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp1.Models.Productsoort", "Parent")
                        .WithMany("Parents")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp1.Models.Productwaarde", b =>
                {
                    b.HasOne("WebApp1.Models.Productsoort", "productsoort")
                        .WithMany("Productwaarde")
                        .HasForeignKey("ProductsoortId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
