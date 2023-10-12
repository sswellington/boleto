using Application.Entities;
using Application.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public sealed class BoletoRepository : IBoletoRepository
{
	public async Task<BoletoEntity> GetById(string id) => new BoletoEntity
	{
		Id = 1,
		NomePagador = "João Silva",
		CpfCnpjPagador = "12345678901",
		NomeBeneficiario = "Empresa XYZ",
		CpfCnpjBeneficiario = "98765432109",
		ValorBrl = 15050,
		DataVencimento = new DateOnly(2023, 10, 20),
		Observacao = "Boleto a vencer",
		BancoId = 1
	};
}
