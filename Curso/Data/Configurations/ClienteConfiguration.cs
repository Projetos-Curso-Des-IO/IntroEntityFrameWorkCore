﻿using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CursoEFCore.Data.Configurations
{
	public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			
				builder.ToTable("Clientes");
				builder.HasKey(c => c.Id);
				builder.Property(c => c.Nome).HasColumnType("VARCHAR(80)").IsRequired();
				builder.Property(c => c.Telefone).HasColumnType("CHAR(11)").IsRequired();
				builder.Property(c => c.CEP).HasColumnType("CHAR(8)").IsRequired();
				builder.Property(c => c.Estado).HasColumnType("CHAR(2)").IsRequired();
				builder.Property(c => c.Cidade).HasMaxLength(60).IsRequired();
				builder.Property(c => c.Email).HasColumnType("VARCHAR(100)").IsRequired();
			
		}
	}
}
