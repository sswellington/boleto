using Application.Entities;
using Application.Interfaces.Repositories;

namespace Infrastructure.Repositories;
public sealed class BancoRepository : IBancoRepository
{
	public async Task<BancoEntity> GetById(string id) => new BancoEntity
	{
		Id = 1,
		Nome = "Banco do Brasil S.A.",
		Codigo = "001",
		PercentualJuros = 0.1,
	};
}
