using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Map
{
	public class PessoaConfig : IEntityTypeConfiguration<Pessoa>
	{
		public void Configure(EntityTypeBuilder<Pessoa> builder)
		{
			builder.ToTable("tblPessoa");

			builder.HasKey(t => t.PessoaId)
				  .HasName("PK_tblPessoa");

			builder.Property(e => e.Nome)
				  .HasMaxLength(50)
				  .IsUnicode(false);

			builder.Property(e => e.SobreNome)
				  .HasMaxLength(50)
				  .IsUnicode(false);

		}
	}
}
