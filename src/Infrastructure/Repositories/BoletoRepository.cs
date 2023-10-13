using Application.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.ObjectRelationalMapping.PostgreSql;

namespace Infrastructure.Repositories;

public sealed class BoletoRepository : BaseRepository<BoletoEntity>, IBoletoRepository
{
	public BoletoRepository(BoletoContext boletoContext) : base(boletoContext) { }
}
