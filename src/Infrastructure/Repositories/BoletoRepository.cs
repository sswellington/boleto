using Application.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.ObjectRelationalMapping.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class BoletoRepository : BaseRepository<BoletoEntity>, IBoletoRepository
{
	public BoletoRepository(BoletoContext boletoContext) : base(boletoContext) { }

	public override async Task<BoletoEntity> GetById(int id)
	{
		var result = await _context.Boleto
			.Include(boleto => boleto.Banco)
			.SingleOrDefaultAsync(q => q.Id == id)
			.ConfigureAwait(false);
		return result ?? new BoletoEntity();
	}
}
