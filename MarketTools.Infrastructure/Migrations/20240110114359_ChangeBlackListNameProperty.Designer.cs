﻿// <auto-generated />
using System;
using MarketTools.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    [DbContext(typeof(MainAppDbContext))]
    [Migration("20240110114359_ChangeBlackListNameProperty")]
    partial class ChangeBlackListNameProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MarketTools.Domain.Entities.AppIdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.SellerConnectionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("character varying(34)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastBadConnectDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("NumConnectionsAttempt")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SellerConnections");

                    b.HasDiscriminator<string>("Discriminator").HasValue("SellerConnectionEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderBanWordEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BlackListId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("BlackListId");

                    b.ToTable("StandardAutoresponderBanWords");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderBlackListEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("StandardAutoresponderBlackLists");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderCell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ColumnId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.HasKey("Id");

                    b.HasIndex("ColumnId");

                    b.ToTable("StandardAutoresponderCells");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderColumnBindPositionEntity", b =>
                {
                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<int>("TemplateId")
                        .HasColumnType("integer");

                    b.Property<int?>("ColumnId")
                        .HasColumnType("integer");

                    b.HasKey("Position", "TemplateId");

                    b.HasIndex("ColumnId");

                    b.HasIndex("TemplateId");

                    b.ToTable("StandardAutoresponderColumnBindPositions");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderColumnEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("StandardAutoresponderColumns");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderConnectionEntity", b =>
                {
                    b.Property<int>("SellerConnectionId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("SellerConnectionId");

                    b.ToTable("StandardAutoresponderConnections");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderConnectionRatingEntity", b =>
                {
                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("ConnectionId")
                        .HasColumnType("integer");

                    b.HasKey("Rating", "ConnectionId");

                    b.HasIndex("ConnectionId");

                    b.ToTable("StandardAutoresponderConnectionRatings");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderRecommendationProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FeedbackArticle")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("FeedbackProductName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("MarketplaceName")
                        .HasColumnType("integer");

                    b.Property<string>("RecommendationArticle")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("RecommendationProductName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("StandardAutoresponderRecommendationProducts");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderTemplateArticleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Article")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TemplateId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("StandardAutoresponderTemplateArticles");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderTemplateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BlackListId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BlackListId");

                    b.HasIndex("UserId");

                    b.ToTable("StandardAutoresponderTemplates");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderTemplateSettingsEntity", b =>
                {
                    b.Property<int>("TemplateId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsSkipEmptyFeedbacks")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSkipWithTextFeedbacks")
                        .HasColumnType("boolean");

                    b.HasKey("TemplateId");

                    b.ToTable("StandardAutoresponderTemplateSettings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StandardAutoresponderConnectionRatingEntityStandardAutoresponderTemplateEntity", b =>
                {
                    b.Property<int>("TemplatesId")
                        .HasColumnType("integer");

                    b.Property<int>("RatingsRating")
                        .HasColumnType("integer");

                    b.Property<int>("RatingsConnectionId")
                        .HasColumnType("integer");

                    b.HasKey("TemplatesId", "RatingsRating", "RatingsConnectionId");

                    b.HasIndex("RatingsRating", "RatingsConnectionId");

                    b.ToTable("StandardAutoresponderConnectionRatingEntityStandardAutorespond~");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.OzonOpenApiSellerConnectionEntity", b =>
                {
                    b.HasBaseType("MarketTools.Domain.Entities.SellerConnectionEntity");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.HasDiscriminator().HasValue("OzonOpenApiSellerConnectionEntity");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.WbOpenApiSellerConnectionEntity", b =>
                {
                    b.HasBaseType("MarketTools.Domain.Entities.SellerConnectionEntity");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.ToTable("SellerConnections", t =>
                        {
                            t.Property("Token")
                                .HasColumnName("WbOpenApiSellerConnectionEntity_Token");
                        });

                    b.HasDiscriminator().HasValue("WbOpenApiSellerConnectionEntity");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.SellerConnectionEntity", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.AppIdentityUser", "User")
                        .WithMany("SellerConnections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderBanWordEntity", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.StandardAutoresponderBlackListEntity", "BlackList")
                        .WithMany("BanWords")
                        .HasForeignKey("BlackListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlackList");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderBlackListEntity", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.AppIdentityUser", "User")
                        .WithMany("StandardAutoresponderBlackLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderCell", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.StandardAutoresponderColumnEntity", "Column")
                        .WithMany("Cells")
                        .HasForeignKey("ColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Column");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderColumnBindPositionEntity", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.StandardAutoresponderColumnEntity", "Column")
                        .WithMany("BindPositions")
                        .HasForeignKey("ColumnId");

                    b.HasOne("MarketTools.Domain.Entities.StandardAutoresponderTemplateEntity", "Template")
                        .WithMany("BindPositions")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_StandardAutoresponderColumnBindPositions_StandardAutorespo~1");

                    b.Navigation("Column");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderColumnEntity", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.AppIdentityUser", "User")
                        .WithMany("StandardAutoreponderColumns")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderConnectionEntity", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.SellerConnectionEntity", "SellerConnection")
                        .WithOne("AutoresponderConnection")
                        .HasForeignKey("MarketTools.Domain.Entities.StandardAutoresponderConnectionEntity", "SellerConnectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SellerConnection");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderConnectionRatingEntity", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.StandardAutoresponderConnectionEntity", "Connection")
                        .WithMany("Ratings")
                        .HasForeignKey("ConnectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Connection");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderRecommendationProductEntity", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.AppIdentityUser", "User")
                        .WithMany("StandardAutoresponderRecommendationProducts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderTemplateArticleEntity", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.StandardAutoresponderTemplateEntity", "Template")
                        .WithMany("Articles")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderTemplateEntity", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.StandardAutoresponderBlackListEntity", "BlackList")
                        .WithMany("Templates")
                        .HasForeignKey("BlackListId");

                    b.HasOne("MarketTools.Domain.Entities.AppIdentityUser", "User")
                        .WithMany("StandardAutoresponderTemplates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlackList");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderTemplateSettingsEntity", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.StandardAutoresponderTemplateEntity", "Template")
                        .WithOne("Settings")
                        .HasForeignKey("MarketTools.Domain.Entities.StandardAutoresponderTemplateSettingsEntity", "TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketTools.Domain.Entities.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StandardAutoresponderConnectionRatingEntityStandardAutoresponderTemplateEntity", b =>
                {
                    b.HasOne("MarketTools.Domain.Entities.StandardAutoresponderTemplateEntity", null)
                        .WithMany()
                        .HasForeignKey("TemplatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketTools.Domain.Entities.StandardAutoresponderConnectionRatingEntity", null)
                        .WithMany()
                        .HasForeignKey("RatingsRating", "RatingsConnectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_StandardAutoresponderConnectionRatingEntityStandardAutores~1");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.AppIdentityUser", b =>
                {
                    b.Navigation("SellerConnections");

                    b.Navigation("StandardAutoreponderColumns");

                    b.Navigation("StandardAutoresponderBlackLists");

                    b.Navigation("StandardAutoresponderRecommendationProducts");

                    b.Navigation("StandardAutoresponderTemplates");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.SellerConnectionEntity", b =>
                {
                    b.Navigation("AutoresponderConnection")
                        .IsRequired();
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderBlackListEntity", b =>
                {
                    b.Navigation("BanWords");

                    b.Navigation("Templates");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderColumnEntity", b =>
                {
                    b.Navigation("BindPositions");

                    b.Navigation("Cells");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderConnectionEntity", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("MarketTools.Domain.Entities.StandardAutoresponderTemplateEntity", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("BindPositions");

                    b.Navigation("Settings")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
