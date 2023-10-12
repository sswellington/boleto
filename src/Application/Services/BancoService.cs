using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Application.Services;
public sealed class BancoService : IBancoService
{
	private readonly IBancoRepository _bancoRepository;

	public BancoService(IBancoRepository bancoRepository)
	{
		_bancoRepository = bancoRepository;
	}

	public async Task<BancoDto> GetById(string id)
	{
		var model = await _bancoRepository.GetById(id);
		return new BancoDto
		(
			Id: model.Id,
			Nome: model.Nome,
			Codigo: model.Codigo,
			PercentrualJuros: model.PercentrualJuros
		);
	}
}
