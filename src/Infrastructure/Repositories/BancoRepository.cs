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

	public async Task<bool> Register(BancoEntity entity)
	{
		if(entity == null)
			return await Task.FromResult(false);

		if (GetByCodeOfBank(entity.Codigo) == null)
			return await Task.FromResult(false);

		await _context.Banco.AddAsync(entity).ConfigureAwait(false);
		_context.SaveChanges();

		return await Task.FromResult(true);	
	}
}
