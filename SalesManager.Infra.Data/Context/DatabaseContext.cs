using System;
using Microsoft.EntityFrameworkCore;
using SalesManager.Domain.Entities;

namespace SalesManager.Infra.Data.Context
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<User>().ToTable("TBL_USUARIOS");

            base.OnModelCreating(modelBuilder);
        }
    }
}

