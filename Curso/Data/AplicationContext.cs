﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoEFCore.Data.Configurations;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CursoEFCore.Data
{
    public class AplicationContext : DbContext
    {
		private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Cliente> Clientes { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
			//Config string de conexão
			optionsBuilder
				.UseLoggerFactory(_logger)
				.EnableSensitiveDataLogging()
				.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CursoEFCore;Integrated Security=true");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicationContext).Assembly);
		}


	}
}
