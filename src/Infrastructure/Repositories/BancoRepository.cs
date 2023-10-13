using Application.Entities;
using Application.Interfaces.Repositories;
using Infrastructure.ObjectRelationalMapping.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class BancoRepository : BaseRepository<BancoEntity>, IBancoRepository
{
	public BancoRepository(BoletoContext boletoContext) : base(boletoContext) { }

	public async Task<BancoEntity> GetByCodeOfBank(string code)
	{
		if (string.IsNullOrWhiteSpace(code))
			return new BancoEntity();
		var result = await _context.Banco.SingleOrDefaultAsync(q => q.Codigo == code).ConfigureAwait(false);
		return result ?? new BancoEntity();
	}
}
