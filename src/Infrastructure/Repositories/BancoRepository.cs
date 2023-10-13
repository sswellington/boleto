using Application.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.ObjectRelationalMapping.PostgreSql;

namespace Infrastructure.Repositories;

public sealed class BancoRepository : BaseRepository<BancoEntity>, IBancoRepository
{
	public BancoRepository(BoletoContext boletoContext) : base(boletoContext) { }
}
