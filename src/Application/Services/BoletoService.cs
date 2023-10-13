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

	public async Task<BoletoDto> GetById(int id)
	{
		BoletoEntity model = await _boletoRepository.GetById(id);
		return BoletoDto.Entity2Dto(model);
	}
};
