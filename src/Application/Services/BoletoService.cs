using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Application.Services;
public sealed class BoletoService : IBoletoService
{
	private readonly IBoletoRepository _boletoRepository;

	public BoletoService(IBoletoRepository boletoRepository)
	{
		_boletoRepository = boletoRepository;
	}

	private static BoletoEntity HasExpired(BoletoEntity boleto)
	{
		DateTime currentTime = DateTime.UtcNow;

		if (boleto.DataVencimento < DateOnly.FromDateTime(currentTime))
			return boleto;

		boleto.ValorBrl += (boleto.ValorBrl * boleto.Banco!.PercentualJuros);
		return boleto;
	}

	public async Task<BoletoDto> GetById(int id)
	{
		BoletoEntity entity = await _boletoRepository.GetById(id);
		entity = HasExpired(entity);
		return BoletoDto.Entity2Dto(entity);
	}
};
