﻿using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
//using P01_HospitalDatabase;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;



namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

                entity.Property(e => e.Quantity)
                .HasColumnType("Float")
                .IsRequired(true);

                entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");

                entity.HasMany(e => e.Sales)
                .WithOne(s => s.Product)
                .HasForeignKey(s => s.SaleId);
            });

            builder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

                entity.Property(e => e.Email)
                .IsRequired(true)
                .HasMaxLength(80)
                .IsUnicode(false);

                entity.Property(e => e.CreditCardNumber)
                .IsRequired(true);

                entity.HasMany(e => e.Sales)
                .WithOne(e => e.Customer)
                .HasForeignKey(s => s.SaleId);
            });

            builder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(80)
                .IsUnicode(true);

                entity.HasMany(e => e.Sales)
                .WithOne(e => e.Store)
                .HasForeignKey(s => s.SaleId);
            });

            builder.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.SaleId);

                entity.Property(e => e.Date)
                .IsRequired(true)
                .HasColumnType("DATETIME2")
                .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Product)
                .WithMany(s => s.Sales)
                .HasForeignKey(s => s.ProductId);

                entity.HasOne(e => e.Customer)
                .WithMany(e => e.Sales)
                .HasForeignKey(s => s.CustomerId);

                entity.HasOne(e => e.Store)
                .WithMany(s => s.Sales)
                .HasForeignKey(s => s.StoreId);
            });

            
        }
    }
}