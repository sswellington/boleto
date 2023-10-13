using Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ObjectRelationalMapping.PostgreSql;

public partial class BoletoContext : DbContext
{
	public BoletoContext() { }
	public BoletoContext(DbContextOptions<BoletoContext> options) : base(options) { }

	public virtual DbSet<BancoEntity> Banco { get; set; }
	public virtual DbSet<BoletoEntity> Boleto { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<BancoEntity>(entity =>
		{
			entity.ToTable("banco");

			entity.Property(e => e.Id).HasColumnName("id");

			entity.Property(e => e.Nome)
				.HasColumnName("nome_banco")
				.HasMaxLength(255);

			entity.Property(e => e.Codigo)
				.HasColumnName("codigo_banco")
				.HasMaxLength(3);

			entity.Property(e => e.PercentualJuros)
				.HasColumnName("percentual_juros")
				.HasColumnType("NUMERIC(6, 5)");
		});

		modelBuilder.Entity<BoletoEntity>(entity =>
		{
			entity.ToTable("BOLETO");

			entity.Property(e => e.Id).HasColumnName("id");

			entity.Property(e => e.NomePagador)
				.HasColumnName("nome_pagador")
				.HasMaxLength(255);

			entity.Property(e => e.CpfCnpjPagador)
				.HasColumnName("cpf_cnpj_pagador")
				.HasMaxLength(14);

			entity.Property(e => e.NomeBeneficiario)
				.HasColumnName("nome_beneficiario")
				.HasMaxLength(255);

			entity.Property(e => e.CpfCnpjBeneficiario)
				.HasColumnName("cpf_cnpj_beneficiario")
				.HasMaxLength(14);

			entity.Property(e => e.ValorBrl)
				.HasColumnName("valor_brl")
				.HasColumnType("MONEY");

			entity.Property(e => e.DataVencimento)
				.HasColumnName("data_vencimento")
				.HasColumnType("DATE");

			entity.Property(e => e.Observacao)
				.HasColumnName("observacao")
				.HasColumnType("TEXT");

			entity.Property(e => e.BancoId)
				.HasColumnName("bancoId");

			entity.HasOne(d => d.Banco)
				.WithMany(p => p.Boleto)
				.HasForeignKey(d => d.BancoId);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

