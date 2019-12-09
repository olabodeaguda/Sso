﻿// <auto-generated />
using System;
using Business360.sso.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Business360.sso.Data.Migrations
{
    [DbContext(typeof(APPContext))]
    [Migration("20191209185306_intializeDB1")]
    partial class intializeDB1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Business360.sso.Data.Entities.SsoApi", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApiSecrets")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SsoApis");
                });

            modelBuilder.Entity("Business360.sso.Data.Entities.SsoClaim", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("SsoClaims");
                });

            modelBuilder.Entity("Business360.sso.Data.Entities.SsoScope", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<bool>("Emphasize")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Required")
                        .HasColumnType("boolean");

                    b.Property<string>("ShowInDiscoveryDocument")
                        .HasColumnType("text");

                    b.Property<long?>("SsoApiId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SsoApiId");

                    b.ToTable("SsoScopes");
                });

            modelBuilder.Entity("Business360.sso.Data.Entities.SsoClaim", b =>
                {
                    b.HasOne("Business360.sso.Data.Entities.SsoApi", "SsoApi")
                        .WithMany("UserClaims")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Business360.sso.Data.Entities.SsoScope", "SsoScope")
                        .WithMany("SSoClaims")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Business360.sso.Data.Entities.SsoScope", b =>
                {
                    b.HasOne("Business360.sso.Data.Entities.SsoApi", null)
                        .WithMany("SsoScopes")
                        .HasForeignKey("SsoApiId");
                });
#pragma warning restore 612, 618
        }
    }
}