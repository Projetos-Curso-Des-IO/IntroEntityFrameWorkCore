﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CursoEFCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEFCore.Data.Configurations
{
	public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
	{
		public void Configure(EntityTypeBuilder<PedidoItem> builder)
		{
			builder.ToTable("PedidoItens");
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();
			builder.Property(p => p.Valor).HasDefaultValue(1).IsRequired();
			builder.Property(p => p.Desconto).HasDefaultValue(1).IsRequired();
		}
	}
}
