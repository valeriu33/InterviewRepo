﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shareholders.Persistence;

namespace Shareholders.Persistence.Migrations
{
    [DbContext(typeof(ShareholdersContext))]
    [Migration("20210130112447_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Shareholders.Domain.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Shareholders.Domain.Shareholder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shareholders");
                });

            modelBuilder.Entity("Shareholders.Domain.ShareholderCompany", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ShareholderId")
                        .HasColumnType("int");

                    b.Property<decimal>("MoneyInvested")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CompanyId", "ShareholderId");

                    b.HasIndex("ShareholderId");

                    b.ToTable("ShareholderCompanies");
                });

            modelBuilder.Entity("Shareholders.Domain.ShareholderCompany", b =>
                {
                    b.HasOne("Shareholders.Domain.Company", "Company")
                        .WithMany("ShareholderCompany")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shareholders.Domain.Shareholder", "Shareholder")
                        .WithMany("ShareholderCompany")
                        .HasForeignKey("ShareholderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Shareholder");
                });

            modelBuilder.Entity("Shareholders.Domain.Company", b =>
                {
                    b.Navigation("ShareholderCompany");
                });

            modelBuilder.Entity("Shareholders.Domain.Shareholder", b =>
                {
                    b.Navigation("ShareholderCompany");
                });
#pragma warning restore 612, 618
        }
    }
}
