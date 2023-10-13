using Application.Dtos;
using Application.Entities;
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
		BancoEntity model = await _bancoRepository.GetById(id);
		return BancoDto.Entity2Dto(model);
	}

	public async Task<ICollection<BancoDto>> GetAll()
	{
		var entities = await _bancoRepository.GetAll();
		List<BancoDto> dtos = new List<BancoDto>();

		foreach (var item in entities)
			dtos.Add(BancoDto.Entity2Dto(item));

		return dtos;
	}
}
