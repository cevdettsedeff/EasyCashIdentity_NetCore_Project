﻿// <auto-generated />
using System;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyCashIdentityProject.DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230516221947_Identity_table_remove")]
    partial class Identity_table_remove
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EasyCashIdentityProject.EntityLayer.Concrete.CustomerAccount", b =>
                {
                    b.Property<int>("CustomerAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerAccountId"), 1L, 1);

                    b.Property<string>("BankBranch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CustomerAccountBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CustomerAccountCurrency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerAccountId");

                    b.ToTable("CustomerAccounts");
                });

            modelBuilder.Entity("EasyCashIdentityProject.EntityLayer.Concrete.CustomerAccountProcess", b =>
                {
                    b.Property<int>("CustomerAccountProcessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerAccountProcessId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ProcessDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProcessType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerAccountProcessId");

                    b.ToTable("CustomerAccountProcesses");
                });
#pragma warning restore 612, 618
        }
    }
}
